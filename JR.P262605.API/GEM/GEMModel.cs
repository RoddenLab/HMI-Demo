using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace JR.P262605.API.GEM
{
    public class GEMModel
    {
        private readonly CancellationTokenSource CancellationTokenSource = new();
        private readonly List<ADS.AdsItem> ADSItems;
        private readonly ILogger Logger;
        private readonly GEMConfiguration Configuration;
        private ADS.Client ADSClient { get; set; }
        public bool ADSConnected { get; private set; }
        private API.GEMAPIIn APIIn { get; set; } = new(nameof(APIIn));
        private API.GEMAPIOut APIOut { get; set; } = new(nameof(APIOut));

        public GEMModel(ILogger logger, IConfiguration configuration)
        {
            // Set Logger
            Logger = logger;

            // Get Configuration
            Configuration = configuration.GetSection("GEMConfiguration").Get<GEMConfiguration>();

            // Create ADS Client
            ADSClient = new(Logger);

            // Create ADS Items
            ADSItems = new()
            {
                new(nameof(APIOut.HeartbeatEcho), "Stn10_20_GEM.APIOut.HeartbeatEcho", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Done), "Stn10_20_GEM.APIOut.Done", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Nest), "Stn10_20_GEM.APIOut.Nest", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.Error), "Stn10_20_GEM.APIOut.Error", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.RepeatCassette), "Stn10_20_GEM.APIOut.RepeatCassette", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ScanCassette), "Stn10_20_GEM.APIOut.ScanCassette", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LaserJob), "Stn10_20_GEM.APIOut.LaserJob", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AlignWafers), "Stn10_20_GEM.APIOut.AlignWafers", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.GoToAligner), "Stn10_20_GEM.APIOut.GoToAligner", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.GoToBottomOCR), "Stn10_20_GEM.APIOut.GoToBottomOCR", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.GoToLaser), "Stn10_20_GEM.APIOut.GoToLaser", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.GoToLumetrics), "Stn10_20_GEM.APIOut.GoToLumetrics", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.GoToTopOCR), "Stn10_20_GEM.APIOut.GoToTopOCR", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.LazyOCRSearch), "Stn10_20_GEM.APIOut.LazyOCRSearch", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.AnnealWafer), "Stn10_20_GEM.APIOut.AnnealWafer", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureAfter), "Stn10_20_GEM.APIOut.MeasureAfter", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MeasureBefore), "Stn10_20_GEM.APIOut.MeasureBefore", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MinimumPower), "Stn10_20_GEM.APIOut.MinimumPower", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.MaximumPower), "Stn10_20_GEM.APIOut.MaximumPower", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StopOnPowerOOR), "Stn10_20_GEM.APIOut.StopOnPowerOOR", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ReadBottomOCR), "Stn10_20_GEM.APIOut.ReadBottomOCR", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StopOnBottomReadFail), "Stn10_20_GEM.APIOut.StopOnBottomReadFail", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.ReadTopOCR), "Stn10_20_GEM.APIOut.ReadTopOCR", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StopOnTopReadFail), "Stn10_20_GEM.APIOut.StopOnTopReadFail", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.StopOnWaferMapMismatch), "Stn10_20_GEM.APIOut.StopOnWaferMapMismatch", ADS.AdsConnectionType.WriteOnly, APIOut),
                new(nameof(APIOut.RecipePath), "Stn10_20_GEM.APIOut.RecipePath", ADS.AdsConnectionType.WriteOnly, APIOut),

                new(nameof(APIIn.Heartbeat), "Stn10_20_GEM.APIIn.Heartbeat", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Start), "Stn10_20_GEM.APIIn.Start", ADS.AdsConnectionType.ReadOnly, APIIn),
                new(nameof(APIIn.Nest), "Stn10_20_GEM.APIIn.Nest", ADS.AdsConnectionType.WriteOnly, APIIn),
                new(nameof(APIIn.RecipePath), "Stn10_20_GEM.APIIn.RecipePath", ADS.AdsConnectionType.ReadOnly, APIIn)
            };


            if (Configuration.Enabled)
            {
                StartADSClientMonitor();
            }

            APIIn.AdsTagChanged += APIIn_AdsTagChanged;
            APIOut.AdsTagChanged += APIOut_AdsTagChanged;
        }


        private void StartADSClientMonitor()
        {
            _ = Task.Run(async () =>
            {
                ADSConnected = false;

                while (true)
                {
                    if (!ADSClient.Connected)
                    {
                        if (ADSConnected)
                        {
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Disconnected from ADS Server");
                            ADSConnected = false;
                        }

                        try
                        {
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Attempting to Connect ADS Client...");
                            string[] EndPoint = Configuration.ADSEndPoint.Split(':');

                            ADSClient.Connect(EndPoint[0], int.Parse(EndPoint[1]));
                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Connected to ADS Server");

                            Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Subscribing to ADS Tags...");
                            if (ADSClient.Subscribe(ADSItems))
                            {
                                Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Subscribed to ADS Tags");
                                Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Connected to ADS Server");
                                ADSConnected = true;
                            }
                        }
                        catch (Exception Exception)
                        {
                            Logger?.LogError($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Unable to Connect to ADS Client - {Exception.Message}");
                            ADSClient.Disconnect();
                        }
                    }
                    else if (ADSClient.Connected && !ADSConnected)
                    {
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Disconnecting ADS Client");
                        ADSClient.Disconnect();
                        Logger?.LogInformation($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - ADS Client Disconected");
                    }

                    await Task.Delay(2500);
                }
            }, CancellationTokenSource.Token);
        }


        private void APIOut_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            ADS.AdsTag AdsTag = (ADS.AdsTag)sender;

            if (ADSConnected)
            {
                try
                {
                    if (e.PropertyName != nameof(APIOut.HeartbeatEcho))
                    {
                        Logger?.LogTrace($"{Configuration.Name} PLC Write - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
                    }

                    ADSClient.Write($"{AdsTag.Name}.{ e.PropertyName}", e.Value);
                }
                catch
                {
                    Logger?.LogError($"{Configuration.Name} ADS - Unable to write to symbol {e.PropertyName} = {e.Value}");
                }
            }
            else
            {
                Logger?.LogDebug($"{Configuration.Name} ADS {Configuration.ADSEndPoint} - Unable to Write to Symbol - ADS Client Not Connected");
            }
        }

        private void APIIn_AdsTagChanged(object sender, ADS.AdsTagChangedEventArgs e)
        {
            // Log Data Changes
            if (e.PropertyName != nameof(APIIn.Heartbeat))
            {
                ADS.IAdsTag AdsTag = (ADS.IAdsTag)sender;
                Logger?.LogTrace($"{Configuration.Name} PLC Read - {AdsTag.Name}.{e.PropertyName} = {e.Value}");
            }

            if (ADSConnected)
            {
                // Update Heartbeat
                if (e.PropertyName == nameof(APIIn.Heartbeat))
                {
                    APIOut.HeartbeatEcho = APIIn.Heartbeat;

                    if (!APIIn.Start && APIOut.Done)
                    {
                        APIOut.ResetHandshake();
                    }
                }

                // Start Trigger
                if (e.PropertyName == nameof(APIIn.Start))
                {
                    if (APIIn.Start)
                    {
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.RecipePath)}");
                        _ = ADSClient.Read($"{APIIn.Name}.{nameof(APIIn.Nest)}");

                        try
                        {
                            API.GEMAPIOut RecipeData = JsonSerializer.Deserialize<API.GEMAPIOut>(File.ReadAllText(APIIn.RecipePath));

                            APIOut.RepeatCassette = RecipeData.RepeatCassette;
                            APIOut.ScanCassette = RecipeData.ScanCassette;
                            APIOut.LaserJob = RecipeData.LaserJob;
                            APIOut.AlignWafers = RecipeData.AlignWafers;
                            APIOut.GoToAligner = RecipeData.GoToAligner;
                            APIOut.GoToBottomOCR = RecipeData.GoToBottomOCR;
                            APIOut.GoToLaser = RecipeData.GoToLaser;
                            APIOut.GoToLumetrics = RecipeData.GoToLumetrics;
                            APIOut.GoToTopOCR = RecipeData.GoToTopOCR;
                            APIOut.LazyOCRSearch = RecipeData.LazyOCRSearch;
                            APIOut.AnnealWafer = RecipeData.AnnealWafer;
                            APIOut.MeasureAfter = RecipeData.MeasureAfter;
                            APIOut.MeasureBefore = RecipeData.MeasureBefore;
                            APIOut.MinimumPower = RecipeData.MinimumPower;
                            APIOut.MaximumPower = RecipeData.MaximumPower;
                            APIOut.StopOnPowerOOR = RecipeData.StopOnPowerOOR;
                            APIOut.ReadBottomOCR = RecipeData.ReadBottomOCR;
                            APIOut.StopOnBottomReadFail = RecipeData.StopOnBottomReadFail;
                            APIOut.ReadTopOCR = RecipeData.ReadTopOCR;
                            APIOut.StopOnTopReadFail = RecipeData.StopOnTopReadFail;
                            APIOut.StopOnWaferMapMismatch = RecipeData.StopOnWaferMapMismatch;

                            APIOut.RecipePath = APIIn.RecipePath;
                            APIOut.Error = false;
                            APIOut.Nest = APIIn.Nest;

                            APIOut.Done = true;
                        }
                        catch (Exception Exception)
                        {
                            Logger?.LogError($"{Configuration.Name} Unable to Set Recipe - Exception {Exception}");

                            APIOut.Error = true;
                            APIOut.Done = true;
                        }
                    }
                    else
                    {
                        APIOut.ResetHandshake();
                    }
                }
            }
        }
    }
}
