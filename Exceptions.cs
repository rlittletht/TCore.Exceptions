using System;
#if DEBUG
using NUnit.Framework;
#endif

namespace TCore.Exceptions
{
    class TcErrorMessages
    {
        public const string Unknown = "Unknown exception";
    }

    public class TcException : Exception
    {
        private Guid m_crids;

        public TcException(Exception exc) : base(exc.Message)
        {
            m_crids = Guid.Empty;
        }

        public TcException(Guid crids) : base(TcErrorMessages.Unknown)
        {
            m_crids = crids;
        }

        public TcException(Guid crids, string sMessage, params object[] rgo) : base(String.Format(sMessage, rgo))
        {
            m_crids = crids;
        }

        public TcException(Guid crids, Exception innerException, string sMessage, params object[] rgo) : base(String.Format(sMessage, rgo), innerException)
        {
            m_crids = crids;
        }

        public TcException(string sMessage, params object[] rgo) : base(String.Format(sMessage, rgo))
        {
            m_crids = Guid.Empty;
        }

        public TcException(Exception innerException, string sMessage, params object[] rgo) : base(String.Format(sMessage, rgo), innerException)
        {
            m_crids = Guid.Empty;
        }

        public TcException() : base(TcErrorMessages.Unknown)  { }

        public Guid Crids => m_crids;

#if DEBUG
        [Test]
        public static void TestTwException()
        {
            try
                {
                throw new TcException("Should be caught");
                }
            catch (TcException exc)
                {
                Assert.AreEqual("Should be caught", exc.Message);
                }
        }
#endif
    }

}
