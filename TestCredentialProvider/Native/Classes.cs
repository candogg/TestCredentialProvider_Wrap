namespace TestCredentialProvider.Native
{
    public class HResult
    {
        public const int Ok = 0x00000000;
        public const int False = 0x00000001;
        public const int NotImplemented = unchecked((int)0x80004001);
        public const int Fail = unchecked((int)0x80004005);
        public const int InvalidArg = unchecked((int)0x80070057);
        public const int UnExpected = unchecked((int)0x8000FFFFL);
    }
}
