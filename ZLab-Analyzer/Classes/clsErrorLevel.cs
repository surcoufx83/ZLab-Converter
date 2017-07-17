namespace ZLab_Analyzer
{
    public static class clsErrorLevel
    {

        /// <summary>
        /// There is no severity defined. Just used for compatibility.
        /// </summary>
        public const int Undefined = 0;

        /// <summary>
        /// This entries contains some information messages that are not a problem for going on.
        /// </summary>
        public const int Information = 10;

        /// <summary>
        /// This exceptions will be a problem. Maybe a file can't be handled or something else. At least, the user should get a feedback about this.
        /// </summary>
        public const int Exception = 20;

        /// <summary>
        /// This is a huge problem as the application has to be restarted.
        /// </summary>
        public const int SoftwareCrash = 40;

    }
}
