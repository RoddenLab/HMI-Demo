using Workstation.ServiceModel.Ua;

namespace JR.P262605.HMI.UI.TypeLibrary
{
    [DataTypeId("ns=4;s=stRecipe")]
    [BinaryEncodingId("nsu=urn:BeckhoffAutomation:Ua:PLC1;s=<StructuredDataType>:stRecipe__DefaultBinary")]
    public class stRecipe : IEncodable
    {
        public stRecipe()
        {

        }

        public stRecipe(Recipe.RecipeModel recipe)
        {
            RepeatCassette = recipe.RepeatCassette;
            ScanCassette = recipe.ScanCassette;
            LaserJob = recipe.LaserJob;
            AlignWafers = recipe.AlignWafers;
            GoToAligner = recipe.GoToAligner;
            GoToBottomOCR = recipe.GoToBottomOCR;
            GoToLaser = recipe.GoToLaser;
            GoToLumetrics = recipe.GoToLumetrics;
            GoToTopOCR = recipe.GoToTopOCR;
            LazyOCRSearch = recipe.LazyOCRSearch;
            AnnealWafer = recipe.AnnealWafer;
            MeasureAfter = recipe.MeasureAfter;
            MeasureBefore = recipe.MeasureBefore;
            MinimumPower = recipe.MinimumPower;
            MaximumPower = recipe.MaximumPower;
            StopOnPowerOOR = recipe.StopOnPowerOOR;
            ReadBottomOCR = recipe.ReadBottomOCR;
            StopOnBottomReadFail = recipe.StopOnBottomReadFail;
            ReadTopOCR = recipe.ReadTopOCR;
            StopOnTopReadFail = recipe.StopOnTopReadFail;
            StopOnWaferMapMismatch = recipe.StopOnWaferMapMismatch;
            RecipePath = recipe.RecipePath;
        }

        public bool RepeatCassette { get; set; } = false;
        public bool ScanCassette { get; set; } = false;
        public string LaserJob { get; set; } = string.Empty;
        public bool AlignWafers { get; set; } = false;
        public bool GoToAligner { get; set; } = false;
        public bool GoToBottomOCR { get; set; } = false;
        public bool GoToLaser { get; set; } = false;
        public bool GoToLumetrics { get; set; } = false;
        public bool GoToTopOCR { get; set; } = false;
        public bool LazyOCRSearch { get; set; } = false;
        public bool AnnealWafer { get; set; } = false;
        public bool MeasureAfter { get; set; } = false;
        public bool MeasureBefore { get; set; } = false;
        public double MinimumPower { get; set; } = 0.0;
        public double MaximumPower { get; set; } = 0.0;
        public bool StopOnPowerOOR { get; set; } = false;
        public bool ReadBottomOCR { get; set; } = false;
        public bool StopOnBottomReadFail { get; set; } = false;
        public bool ReadTopOCR { get; set; } = false;
        public bool StopOnTopReadFail { get; set; } = false;
        public bool StopOnWaferMapMismatch { get; set; } = false;
        public string RecipePath { get; set; } = string.Empty;

        public void Decode(IDecoder decoder)
        {
            RepeatCassette = decoder.ReadBoolean(nameof(RepeatCassette));
            ScanCassette = decoder.ReadBoolean(nameof(ScanCassette));
            LaserJob = decoder.ReadString(nameof(LaserJob));
            AlignWafers = decoder.ReadBoolean(nameof(AlignWafers));
            GoToAligner = decoder.ReadBoolean(nameof(GoToAligner));
            GoToBottomOCR = decoder.ReadBoolean(nameof(GoToBottomOCR));
            GoToLaser = decoder.ReadBoolean(nameof(GoToLaser));
            GoToLumetrics = decoder.ReadBoolean(nameof(GoToLumetrics));
            GoToTopOCR = decoder.ReadBoolean(nameof(GoToTopOCR));
            LazyOCRSearch = decoder.ReadBoolean(nameof(LazyOCRSearch));
            AnnealWafer = decoder.ReadBoolean(nameof(AnnealWafer));
            MeasureAfter = decoder.ReadBoolean(nameof(MeasureAfter));
            MeasureBefore = decoder.ReadBoolean(nameof(MeasureBefore));
            MinimumPower = decoder.ReadDouble(nameof(MinimumPower));
            MaximumPower = decoder.ReadDouble(nameof(MaximumPower));
            StopOnPowerOOR = decoder.ReadBoolean(nameof(StopOnPowerOOR));
            ReadBottomOCR = decoder.ReadBoolean(nameof(ReadBottomOCR));
            StopOnBottomReadFail = decoder.ReadBoolean(nameof(StopOnBottomReadFail));
            ReadTopOCR = decoder.ReadBoolean(nameof(ReadTopOCR));
            StopOnTopReadFail = decoder.ReadBoolean(nameof(StopOnTopReadFail));
            StopOnWaferMapMismatch = decoder.ReadBoolean(nameof(StopOnWaferMapMismatch));
            RecipePath = decoder.ReadString(nameof(RecipePath));
        }

        public void Encode(IEncoder encoder)
        {
            encoder.WriteBoolean(nameof(RepeatCassette), RepeatCassette);
            encoder.WriteBoolean(nameof(ScanCassette), ScanCassette);
            encoder.WriteString(nameof(LaserJob), LaserJob);
            encoder.WriteBoolean(nameof(AlignWafers), AlignWafers);
            encoder.WriteBoolean(nameof(GoToAligner), GoToAligner);
            encoder.WriteBoolean(nameof(GoToBottomOCR), GoToBottomOCR);
            encoder.WriteBoolean(nameof(GoToLaser), GoToLaser);
            encoder.WriteBoolean(nameof(GoToLumetrics), GoToLumetrics);
            encoder.WriteBoolean(nameof(GoToTopOCR), GoToTopOCR);
            encoder.WriteBoolean(nameof(LazyOCRSearch), LazyOCRSearch);
            encoder.WriteBoolean(nameof(AnnealWafer), AnnealWafer);
            encoder.WriteBoolean(nameof(MeasureAfter), MeasureAfter);
            encoder.WriteBoolean(nameof(MeasureBefore), MeasureBefore);
            encoder.WriteDouble(nameof(MinimumPower), MinimumPower);
            encoder.WriteDouble(nameof(MaximumPower), MaximumPower);
            encoder.WriteBoolean(nameof(StopOnPowerOOR), StopOnPowerOOR);
            encoder.WriteBoolean(nameof(ReadBottomOCR), ReadBottomOCR);
            encoder.WriteBoolean(nameof(StopOnBottomReadFail), StopOnBottomReadFail);
            encoder.WriteBoolean(nameof(ReadTopOCR), ReadTopOCR);
            encoder.WriteBoolean(nameof(StopOnTopReadFail), StopOnTopReadFail);
            encoder.WriteBoolean(nameof(StopOnWaferMapMismatch), StopOnWaferMapMismatch);
            encoder.WriteString(nameof(RecipePath), RecipePath);
        }
    }
}
