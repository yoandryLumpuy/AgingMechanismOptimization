namespace Core.Domain
{
    public static class TransferStatusValues
    {
        /// <summary>
        /// 
        /// </summary>
        public const string FailedPostingToExternalSystem = "*";
        /// <summary>
        /// 
        /// </summary>
        public const string ToBeDisbursedToSuspenseAccount = "B";
        /// <summary>
        /// 
        /// </summary>
        public const string Cancelled = "C";
        /// <summary>
        /// 
        /// </summary>
        public const string DisbursedOverTheCounter = "D";
        /// <summary>
        /// 
        /// </summary>
        public const string ReinstatedForDisbursement = "E";
        /// <summary>
        /// 
        /// </summary>
        public const string DisbursedToSuspenseAccount = "F";
        /// <summary>
        /// 
        /// </summary>
        public const string AttemptedTopUp = "G";
        /// <summary>
        /// 
        /// </summary>
        public const string AttemptedPostingToExternalSystem = "H";
        /// <summary>
        /// 
        /// </summary>
        public const string Incorrect = "I";
        /// <summary>
        /// 
        /// </summary>
        public const string DisbursedToRemoteFinancialSystemByPosting = "O";
        /// <summary>
        /// 
        /// </summary>
        public const string Posted = "P";
        /// <summary>
        /// 
        /// </summary>
        public const string DisbursedToRemoteFinancialSystemByCheque = "Q";
        /// <summary>
        /// 
        /// </summary>
        public const string ToBeDisburseToPhoenix = "R";
        /// <summary>
        /// 
        /// </summary>
        public const string Suspended = "S";

        /// <summary>
        /// 
        /// </summary>
        public const string DisbursedToPhoenix = "X";
        /// <summary>
        /// 
        /// </summary>
        public const string ReinstatedForCancellation = "T";
        /// <summary>
        /// 
        /// </summary>
        public const string Undisbursed = "U";
        /// <summary>
        /// 
        /// </summary>
        public const string PendingDisbursement = "Y";
        /// <summary>
        /// 
        /// </summary>
        public const string AgedLevel1 = "J";
        /// <summary>
        /// 
        /// </summary>
        public const string AgedLevel2 = "K";
        /// <summary>
        /// 
        /// </summary>
        public const string AgedLevel3 = "L";
    }
}
