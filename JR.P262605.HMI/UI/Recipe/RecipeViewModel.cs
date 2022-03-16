using JR.WPF;
using Serilog;
using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Recipe
{
    public class RecipeViewModel : BindableBase
    {
        private const string TitleRoot = "JR-Automation Recipe Editor";
        private string FileName = string.Empty;

        public RecipeModel Model { get; set; } = new();

        public RecipeViewModel()
        {
            LoadDataCommand = new Command(OnLoadData);
            SaveDataCommand = new Command(OnSaveData);
            SelectRecipeCommand = new Command(OnSelectRecipeCommand);
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Title != TitleRoot)
            {
                Title = Title.EndsWith("*") ? Title : Title + "*";
            }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand SaveDataCommand { get; private set; }
        public ICommand SelectRecipeCommand { get; private set; }

        private void OnLoadData()
        {
            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "JR Files (*.jr)|*.jr|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    RecipeModel RecipeModel = JsonSerializer.Deserialize<RecipeModel>(File.ReadAllText(OpenFileDialog.FileName));

                    Model.SetData(RecipeModel);

                    Title = $"{TitleRoot} - {OpenFileDialog.FileName}";
                }
                catch (Exception Exception)
                {
                    Log.Error(Exception.Message);
                }
            }
        }

        private void OnSaveData()
        {
            SaveFileDialog SaveFileDialog = new();

            SaveFileDialog.Filter = "JR Files (*.jr)|*.jr|All Files(*.*)|*.*";

            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JsonSerializerOptions Options = new(JsonSerializerDefaults.General)
                    {
                        WriteIndented = true
                    };

                    File.WriteAllText(SaveFileDialog.FileName, JsonSerializer.Serialize(Model, Options));

                    FileName = SaveFileDialog.FileName;
                    Title = $"{TitleRoot} - {FileName}";
                }
                catch (Exception Exception)
                {
                    Log.Error(Exception.Message);
                }
            }
        }

        private void OnSelectRecipeCommand()
        {
            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "Weldmark Files (*.wmj3)|*.wmj3|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Model.LaserJob = OpenFileDialog.FileName.Replace("C:", $"\\\\{Environment.MachineName}");
            }
        }

        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }
        private string _Title = TitleRoot;
    }
}
