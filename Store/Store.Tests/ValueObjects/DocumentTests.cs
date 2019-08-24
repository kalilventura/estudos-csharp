using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private readonly Document validDocument;
        private readonly Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("40771124864");
            invalidDocument = new Document("12345678910");
        }
        [TestMethod]
        public void ShouldRetornNotificationWhenDocumentIsNotValid()
        {

            Assert.AreEqual(false, invalidDocument.Valid);
        }

        [TestMethod]
        public void ShouldRetornNotificationWhenDocumentIsValid()
        {

            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
