using JR.WPF;
using Microsoft.Win32;
using Serilog;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Data
{
    public class CassetteViewModel : BindableBase
    {
        public CassetteModel Model { get; set; } = new();

        public CassetteViewModel()
        {
            LoadDataCommand = new Command(OnLoadData);
            SaveDataCommand = new Command(OnSaveData);
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand SaveDataCommand { get; private set; }

        private void OnLoadData()
        {
            System.Windows.Forms.OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "Cassette Data Files (*.data)|*.data|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CassetteModel CassetteData = JsonSerializer.Deserialize<CassetteModel>(File.ReadAllText(OpenFileDialog.FileName));
                    Model.SetData(CassetteData);
                }
                catch (Exception Exception)
                {
                    Log.Error(Exception.Message);
                }
            }
        }

        private void OnSaveData()
        {
            System.Windows.Forms.SaveFileDialog SaveFileDialog = new();

            SaveFileDialog.Filter = "Cassette Data Files (*.data)|*.data|All Files(*.*)|*.*";

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create JR File
                    JsonSerializerOptions Options = new(JsonSerializerDefaults.General)
                    {
                        WriteIndented = true
                    };

                    File.WriteAllText(SaveFileDialog.FileName, JsonSerializer.Serialize(Model, Options));
                }
                catch (Exception Exception)
                {
                    Log.Error(Exception.Message);
                }
            }
        }
    }
}