using System;
using System.Diagnostics;
using System.Linq;
using Antlr4.Runtime.Tree;
using MicroserviceMatrixDSL.AntlrBasedTranspiler.Generated;
using MicroserviceMatrixDSL.Builder.Interfaces;
using MicroserviceMatrixDSL.Descriptions;

namespace MicroserviceMatrixDSL.AntlrBasedTranspiler
{
    public class MsdlParseTreeListener : microservice_description_languageBaseListener
    {
        private IInfrastructureDesciptionBuilder _infrastructureDesciptionBuilder;
        private IMessageTypeDescriptionBuilder _messageTypeDescriptionBuilder;
        private IMicroserviceDescriptionBuilder _microserviceDescriptionBuilder;

        public MsdlParseTreeListener(
            IInfrastructureDesciptionBuilder infrastructureDesciptionBuilder,
            IMicroserviceDescriptionBuilder microserviceDescriptionBuilder,
            IMessageTypeDescriptionBuilder messageTypeDescriptionBuilder)
        {
            _microserviceDescriptionBuilder = microserviceDescriptionBuilder;
            _infrastructureDesciptionBuilder = infrastructureDesciptionBuilder;
            _messageTypeDescriptionBuilder = messageTypeDescriptionBuilder;
        }

        public MicroserviceInfrastructureDescription Create()
        {
            return _infrastructureDesciptionBuilder.Create();
        }

        public override void ExitDefault_microservice_namespace_declaration(
            microservice_description_languageParser.Default_microservice_namespace_declarationContext context)
        {
            _infrastructureDesciptionBuilder =
                _infrastructureDesciptionBuilder
                    .WithDefaultMicroserviceNamespace(context.default_microservice_namespace.Text);

            _microserviceDescriptionBuilder =
                _microserviceDescriptionBuilder
                    .WithinNamespace(context.default_microservice_namespace.Text);
        }

        public override void ExitDefault_message_namespace_declaration(
            microservice_description_languageParser.Default_message_namespace_declarationContext context)
        {
            _infrastructureDesciptionBuilder
                = _infrastructureDesciptionBuilder
                    .WithDefaultMessageNamespace(context.default_message_namespace.Text);

            _messageTypeDescriptionBuilder =
                _messageTypeDescriptionBuilder
                    .WithNamespace(context.default_message_namespace.Text);
            Debug.WriteLine("###Default namespace namespace declaration:" + context.default_message_namespace);
        }

        public override void ExitDefault_communication_declaration(
            microservice_description_languageParser.Default_communication_declarationContext context)
        {
            _infrastructureDesciptionBuilder =
                _infrastructureDesciptionBuilder
                    .WithDefaultCommunicationMean(context.communication_name.Text);

            _microserviceDescriptionBuilder =
                _microserviceDescriptionBuilder
                    .WithCommunicationMean(context.communication_name.Text);

            Debug.WriteLine("###Default communication declaration:" + context.communication_name);
        }

        public override void ExitMessage_declaration(
            microservice_description_languageParser.Message_declarationContext context)
        {
            Debug.WriteLine("###Message declaration:" + context.message_name);
            var messageBuilder = _messageTypeDescriptionBuilder
                .WithTypeName(context.message_name.Text);
            var descriptionContext = context.message_description().FirstOrDefault();
            if (descriptionContext != null)
            {
                messageBuilder = messageBuilder.WithNamespace(descriptionContext.@namespace.Text);
                Debug.WriteLine("\t###Description: " + descriptionContext.@namespace);
            }
            _infrastructureDesciptionBuilder =
                _infrastructureDesciptionBuilder
                    .WithDeclaredMessage(messageBuilder.Create());
        }

        public override void ExitMicroservice_declaration(
            microservice_description_languageParser.Microservice_declarationContext context)
        {
            Debug.WriteLine("###Microservice declaration:" + context.microservice_name);
            var microserviceBuilder =
                _microserviceDescriptionBuilder
                    .WithName(context.microservice_name.Text);

            context.microservice_description().ToList().ForEach(desc =>
            {
                if (desc.mixin_declaration() != null)
                {
                    microserviceBuilder = microserviceBuilder
                        .Extends(desc.mixin_declaration().like_microservice.Text);
                    Debug.WriteLine("\t" + desc.mixin_declaration().like_microservice);
                }
                if (desc.received_message_declaration() != null)
                {
                    if (desc.received_message_declaration().responds != null)
                    {
                        microserviceBuilder =
                            microserviceBuilder.RespondsToWith(
                                desc.received_message_declaration().receives.Text,
                                desc.received_message_declaration().responds.Text
                                );
                    }
                    else
                    {
                        microserviceBuilder =
                            microserviceBuilder.RespondsTo(
                                desc.received_message_declaration().receives.Text
                                );
                    }

                    Debug.WriteLine("\t" + desc.received_message_declaration().receives + "->"
                                    + desc.received_message_declaration().responds);
                }
                if (desc.sended_message_declaration() != null)
                {
                    microserviceBuilder = microserviceBuilder
                        .Sends(desc.sended_message_declaration().sends.Text);

                    Debug.WriteLine("\t" + desc.sended_message_declaration().sends);
                }
                if (desc.used_communication() != null)
                {
                    microserviceBuilder =
                        microserviceBuilder.WithCommunicationMean(
                            desc.used_communication().communication_name.Text);
                    Debug.WriteLine("\t" + desc.used_communication().communication_name);
                }
            });
            _infrastructureDesciptionBuilder =
                _infrastructureDesciptionBuilder.WithMicroservice(microserviceBuilder.Create());
        }

        public override void VisitErrorNode(IErrorNode node)
        {
            throw new Exception(node.ToString());
        }
    }
}