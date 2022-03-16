using JR.WPF;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace JR.P262605.HMI.UI.Main
{
    public class MainViewModel : BindableBase
    {
        private readonly ILogger Logger;
        private readonly IAppConfiguration Configuration;
        public bool TopCameraEnabled { get; set; }
        public bool LumetricsEnabled { get; set; }
        public bool LaserEnabled { get; set; }

        public MainModel Model { get; set; }

        public MainViewModel(ILogger logger, IAppConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration;

            Model = new();
            SelectWaferCommand = new Command((index) => SelectWafer(index));
            LoadDataCommand = new Command((cassette) => OnLoadDataCommand(cassette));

            PlaceCassetteACommand = new AsyncCommand(OnPlaceCassetteACommand);
            PlaceCassetteBCommand = new AsyncCommand(OnPlaceCassetteBCommand);

            SelectCassetteDataCommand = new Command((cassette) => OnSelectCassetteDataCommand(cassette));

            SelectRecipeCommand = new Command((cassette) => OnSelectRecipeCommand(cassette));
            SetCassetteARecipeCommand = new AsyncCommand(OnSetCassetteARecipeCommand);
            SetCassetteBRecipeCommand = new AsyncCommand(OnSetCassetteBRecipeCommand);
        }

        public ICommand SelectCassetteDataCommand { get; private set; }
        private void OnSelectCassetteDataCommand(object cassette)
        {
            string Cassette = (string)cassette;

            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "Cassette Data Files (*.data)|*.data|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (Cassette)
                {
                    case "A":
                        Model.hiCassetteADataFile = OpenFileDialog.FileName;
                        break;
                    case "B":
                        Model.hiCassetteBDataFile = OpenFileDialog.FileName;
                        break;
                }
            }
        }

        public ICommand SelectRecipeCommand { get; private set; }
        private void OnSelectRecipeCommand(object cassette)
        {
            string Cassette = (string)cassette;


            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "Recipe Files (*.jr)|*.jr|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (Cassette)
                {
                    case "A":
                        Model.hiCassetteARecipeFile = OpenFileDialog.FileName;
                        break;
                    case "B":
                        Model.hiCassetteBRecipeFile = OpenFileDialog.FileName;
                        break;
                }
            }
        }

        public ICommand SelectWaferCommand { get; private set; }

        private void SelectWafer(object obj)
        {
            string Index = (string)obj;

            Model.SelectedCassette = Index[0].ToString();
            Model.SelectedSlot = int.Parse(Index[1..]);
        }

        public ICommand LoadDataCommand { get; private set; }

        private void OnLoadDataCommand(object cassette)
        {
            string Cassette = (string)cassette;
            Data.CassetteModel CassetteData = null;

            OpenFileDialog OpenFileDialog = new();
            OpenFileDialog.Filter = "JR Files (*.jr)|*.jr|All Files(*.*)|*.*";
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CassetteData = JsonSerializer.Deserialize<Data.CassetteModel>(File.ReadAllText(OpenFileDialog.FileName));
                }
                catch (Exception Exception)
                {
                    Logger?.LogError(Exception.Message);
                }
            }

            if (CassetteData is not null)
            {
                Model.SetCassetteData(Cassette, CassetteData);

                if (Cassette == "A")
                {
                    Model.hiCassetteADataFile = OpenFileDialog.FileName;
                }
                else if (Cassette == "B")
                {
                    Model.hiCassetteBDataFile = OpenFileDialog.FileName;
                }
            }
        }

        public ICommand PlaceCassetteACommand { get; private set; }

        private async Task OnPlaceCassetteACommand()
        {
            Logger?.LogInformation($"User Pressed Place Cassette A Command. Cassette File - {Model.hiCassetteADataFile}");

            try
            {
                Data.CassetteModel CassetteData = JsonSerializer.Deserialize<Data.CassetteModel>(File.ReadAllText(Model.hiCassetteADataFile));

                if (CassetteData is not null)
                {
                    Model.SetCassetteData("A", CassetteData);
                    Model.hiCassetteADataFile = Model.hiCassetteADataFile;
                    await Task.Delay(500);
                    Model.hiCassetteAPlaced = true;
                    await Task.Delay(Configuration.ButtonDelay); ;
                    Model.hiCassetteAPlaced = false;
                }
            }
            catch (Exception)
            {
                Logger?.LogError($"Unable to Set Cassette A Data. Cassette File - {Model.hiCassetteADataFile}");
            }
        }

        public ICommand PlaceCassetteBCommand { get; private set; }

        private async Task OnPlaceCassetteBCommand()
        {
            Logger?.LogInformation($"User Pressed Place Cassette B Command. Cassette File - {Model.hiCassetteBDataFile}");

            try
            {
                Data.CassetteModel CassetteData = JsonSerializer.Deserialize<Data.CassetteModel>(File.ReadAllText(Model.hiCassetteBDataFile));

                if (CassetteData is not null)
                {
                    Model.SetCassetteData("B", CassetteData);
                    Model.hiCassetteBDataFile = Model.hiCassetteBDataFile;
                    await Task.Delay(500);
                    Model.hiCassetteBPlaced = true;
                    await Task.Delay(Configuration.ButtonDelay); ;
                    Model.hiCassetteBPlaced = false;
                }
            }
            catch (Exception)
            {
                Logger?.LogError($"Unable to Set Cassette B Data. Cassette File - {Model.hiCassetteBDataFile}");
            }
        }

        public ICommand SetCassetteARecipeCommand { get; private set; }
        private async Task OnSetCassetteARecipeCommand()
        {
            Logger?.LogInformation($"User Pressed Set Cassette A Recipe Command. Recipe File - {Model.hiCassetteARecipeFile}");

            try
            {
                Recipe.RecipeModel RecipeData = JsonSerializer.Deserialize<Recipe.RecipeModel>(File.ReadAllText(Model.hiCassetteARecipeFile));
                RecipeData.RecipePath = Model.hiCassetteARecipeFile;

                if (RecipeData is not null)
                {
                    Model.SetRecipe("A", RecipeData);
                    await Task.Delay(Configuration.ButtonDelay);
                    Model.hiSetCassetteARecipe = true;
                    await Task.Delay(Configuration.ButtonDelay);
                    Model.hiSetCassetteARecipe = false;
                }
            }
            catch (Exception Exception)
            {
                Logger?.LogError($"Unable to Set Recipe A. Recipe File - {Model.hiCassetteARecipeFile}. Exception - {Exception}");
            }
        }

        public ICommand SetCassetteBRecipeCommand { get; private set; }

        private async Task OnSetCassetteBRecipeCommand()
        {
            Logger?.LogInformation($"User Pressed Set Cassette B Recipe Command. Recipe File - {Model.hiCassetteBRecipeFile}");

            try
            {
                Recipe.RecipeModel RecipeData = JsonSerializer.Deserialize<Recipe.RecipeModel>(File.ReadAllText(Model.hiCassetteBRecipeFile));
                RecipeData.RecipePath = Model.hiCassetteBRecipeFile;

                if (RecipeData is not null)
                {
                    Model.SetRecipe("B", RecipeData);
                    await Task.Delay(Configuration.ButtonDelay);
                    Model.hiSetCassetteBRecipe = true;
                    await Task.Delay(Configuration.ButtonDelay);
                    Model.hiSetCassetteBRecipe = false;
                }
            }
            catch (Exception Exception)
            {
                Logger?.LogError($"Unable to Set Recipe B. Recipe File - {Model.hiCassetteBRecipeFile}. Exception - {Exception}");
            }
        }

    }
}