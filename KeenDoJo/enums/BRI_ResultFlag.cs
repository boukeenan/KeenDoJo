namespace KeenDoJo.enums
{
	public enum BRI_ResultFlag
	{
		Clear = 0,
		NotYet = 1,
		AttachFailed = 2,
		ProductionFail = 4,
		MilkingFail = 6,
		TeatTimeLF = 8,
		TeatTimeRF = 16,
		TeatTimeLR = 32,
		TeatTimeRR = 64,
		TeatTime = 120,
		ConductLF = 128,
		ConductRF = 256,
		ConductLR = 512,
		ConductRR = 1024,
		Conduct = 1920,
		ManualMilking = 2048,
		ManualAbort = 4096,
		BloodInMilk = 8192,
		FeedTrainingFlag = 16384,
		MaxMilkTime = 32768,
		ManualConfirmAttention = 262144
	}
}
