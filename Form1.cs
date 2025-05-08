using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.SoundOut;
using CSCore.Streams;

namespace LokiGui
{
    public partial class Form1 : Form
    {
        private MMDevice sourceDevice = null;
        private MMDevice targetDevice = null;
        private WasapiLoopbackCapture soundIn;
        private WasapiOut soundOut;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDevices();
        }

        private void InitializeDevices()
        {
            var deviceEnumerator = new MMDeviceEnumerator();

            // Preenche o ComboBox de dispositivos de reprodução (source)
            var deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active); // DataFlow.Render para dispositivos de reprodução
            foreach (var device in deviceCollection)
            {
                comboBoxSource.Items.Add(device.FriendlyName);
            }

            // Preenche o ComboBox de dispositivos de reprodução (target)
            deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active); // DataFlow.Render para dispositivos de reprodução
            foreach (var device in deviceCollection)
            {
                comboBoxTarget.Items.Add(device.FriendlyName);
            }

            // Se houver dispositivos, seleciona o primeiro
            if (comboBoxSource.Items.Count > 0)
                comboBoxSource.SelectedIndex = 0;

            if (comboBoxTarget.Items.Count > 0)
                comboBoxTarget.SelectedIndex = 0;
        }

        private void DestroyCombosDevices()
        {
            comboBoxSource.Items.Clear();
            comboBoxTarget.Items.Clear();
        }


        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Ativar")
            {
                // Pega os nomes dos dispositivos selecionados nos ComboBoxes
                string sourceName = comboBoxSource.SelectedItem.ToString();
                string targetName = comboBoxTarget.SelectedItem.ToString();
                StartCapture(sourceName, targetName);
                btnStartStop.Text = "Desativar";
            }
            else
            {
                StopCapture();
                btnStartStop.Text = "Ativar";
            }
        }

        private void StartCapture(string sourceName, string targetName)
        {
            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                var deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);

                foreach (var device in deviceCollection)
                {
                    if (sourceDevice == null && DeviceMatches(device, sourceName))
                    {
                        sourceDevice = device;
                    }
                }

                deviceCollection = deviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
                foreach (var device in deviceCollection)
                {
                    if (targetDevice == null && DeviceMatches(device, targetName))
                    {
                        targetDevice = device;
                    }
                }
            }

            if (sourceDevice == null || targetDevice == null)
            {
                MessageBox.Show("Não foi possível encontrar os dispositivos de áudio.");
                return;
            }

            // Inicializa a captura de áudio no dispositivo de origem
            soundIn = new WasapiLoopbackCapture { Device = sourceDevice };
            soundIn.Initialize();

            // Inicializa a saída de áudio no dispositivo de destino
            soundOut = new WasapiOut() { Latency = 200, Device = targetDevice };
            try
            {
                soundOut.Initialize(new SoundInSource(soundIn));
                soundIn.Start();
                soundOut.Play();
                MessageBox.Show("Captura e reprodução de áudio iniciadas.");

                // Começa a monitorar o estado da reprodução
                Task.Run(() => MonitorPlayback());  // Inicia o monitoramento sem bloquear a thread principal

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar a captura e reprodução: " + ex.Message);
            }
        }


        private void StopCapture()
        {
            soundIn?.Stop();
            soundOut?.Stop();
            MessageBox.Show("Captura e reprodução de áudio finalizadas.");
        }

        private bool DeviceMatches(MMDevice device, string name)
        {
            return device.FriendlyName.Equals(name, StringComparison.OrdinalIgnoreCase); // Agora verifica a correspondência exata do nome
        }

        private void MonitorPlayback()
        {
            // Monitorar a captura e reprodução de áudio
            while (true)
            {
                // Verifica o estado da reprodução
                if (soundOut.PlaybackState == PlaybackState.Paused || soundOut.PlaybackState == PlaybackState.Stopped)
                {
                    // Se o áudio foi pausado ou parado, tentamos retomar a reprodução
                    soundOut.Play();
                }

                // Aguardar para evitar uso excessivo de CPU
                Thread.Sleep(100);
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Duplicador de Áudio para permitir o uso de dois fones simultaneamente em um único computador.\n Créditos: Marlon Daniel Jesus");

            string url = "https://lizdesigner.com";
            string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; // Caminho típico do Chrome
            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            try
            {
                if (System.IO.File.Exists(chromePath))
                {
                    System.Diagnostics.Process.Start(chromePath, url);
                }
                else
                {
                    // Se o Chrome não for encontrado, tenta abrir com o Edge
                    System.Diagnostics.Process.Start(edgePath, url);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao abrir o link: {ex.Message}");
            }
        }

        private void recarregarDispositivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DestroyCombosDevices();
            InitializeDevices();
        }
    }
}
