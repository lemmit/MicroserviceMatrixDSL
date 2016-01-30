using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MicroserviceMatrixDSL.DSL.Tests
{
    [TestClass]
    public class DslStatesFactoryTests
    {
        [TestMethod]
        public void Test1()
        {
            new DslStatesFactory().CreateBaseState("Messages", "None", "GeneratedMicroservices")
                .Default().Message().Namespace("DefaultMessageNamespace.Messages")
                .Message().Class("TestMessage")
                .Message().Class("PingMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("PongMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("EchoMessage").Using().Namespace("HeheLolMessages")
                .Message().Class("LogMessage")
                .Message().Class("EmailMessage").Using().Namespace("Common")
                .Default().Namespace("AwesomeMicroservicesCreatedUsingDSL")
                .Microservice("Pinger").Using("RabbitMq").Receives("PingMessage").And().Responds("PongMessage")
                .Microservice("Echo").Using("RabbingMq").Receives("EchoMessage").And().Responds().With("EchoMessage")
                .Default().Communication("REST")
                .Microservice("Logging").Using("RabbitMq").Sends("LogMessage")
                .Microservice("Email").Like("Logging").Using("RabbitMq").Receives("EmailMessage")
                .Flush()
                .Create();
        }

        [TestMethod]
        public void CreateBaseStateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateDefaultsStateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateDeclareNamespaceStateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateMicroserviceDescribingStateTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void CreateMessageTypeDescribingStateTest()
        {
            throw new NotImplementedException();
        }
    }
}