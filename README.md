# MicroserviceMatrixDSL
Full description is available as a blog post [here](http://somethingabout.it/microservice-description-language)

Status: pre-alpha (something works, still pretty buggy)

Input:
```language-csharp
default message namespace DefaultMessageNamespace.Messages

//messages declarations
message class TestMessage
message class PingMessage 
	using namespace HeheLolMessages
message class PongMessage 
	using namespace AnotherLolMessages
message class EchoMessage 
	using namespace HeheLolMessages
message class LogMessage 
	using namespace Common
message class EmailMessage using namespace Common
	
//microservice namespace
default namespace AwesomeMicroservicesCreatedUsingDSL
//microservices declarations
microservice Pinger 
	using RabbitMq 
	receives PingMessage and responds PongMessage
	
microservice Echo 
	using RabbitMq 
	receives EchoMessage and responds with EchoMessage
```

Output:
```language-csharp
/*
GENERATED CODE 2016-03-23 13:44:19
by MicroserviceMatrixDSL tool
(https://github.com/lemmit/MicroserviceMatrixDSL)
*/

namespace AwesomeMicroservicesCreatedUsingDSL {

	public abstract class AbstractPingerService : BaseMicroservice {
		protected AnotherLolMessages.PongMessage ServiceMethod(HeheLolMessages.PingMessage request){
			return onPingMessageRequest();
		}
		protected abstract AnotherLolMessages.PongMessage onPingMessageRequest(HeheLolMessages.PingMessage request);
 	
	}
	public abstract class AbstractEchoService : BaseMicroservice {
		protected HeheLolMessages.EchoMessage ServiceMethod(HeheLolMessages.EchoMessage request){
			return onEchoMessageRequest();
		}
		protected abstract HeheLolMessages.EchoMessage onEchoMessageRequest(HeheLolMessages.EchoMessage request);
 	
	}
}

//END OF GENERATED CODE

```
