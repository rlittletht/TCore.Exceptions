﻿using System;
#if DEBUG
using NUnit.Framework;
#endif

namespace TCore.Exceptions
{
    public class TcException : Exception
    {
        private Guid m_crids;
        private string m_sMessage;

        public TcException(Exception exc)
        {
            m_crids = Guid.Empty;
            m_sMessage = exc.Message;
        }

        public TcException(Guid crids, string sMessage, params object[] rgo)
        {
            m_crids = crids;
            m_sMessage = String.Format(sMessage, rgo);
        }

        public TcException(string sMessage, params object[] rgo)
        {
            m_sMessage = String.Format(sMessage, rgo);
            m_crids = Guid.Empty;
        }

        public TcException()
        {
        }

        public override string Message => m_sMessage;

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
