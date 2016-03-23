grammar microservice_description_language;

options 
{
	language = 'CSharp3'; 
}

microservice_description_language 
		: (statement | COMMENT)+
		;

statement 
		: default_message_namespace_declaration
	| default_microservice_namespace_declaration
	| default_communication_declaration
	| message_declaration 
	| microservice_declaration
		;

default_message_namespace_declaration
	: DEFAULT MESSAGE NAMESPACE IS* (default_message_namespace=ID);

default_microservice_namespace_declaration
		: DEFAULT MICROSERVICE* NAMESPACE IS* (default_microservice_namespace=ID);

default_communication_declaration 
	: DEFAULT COMMUNICATION IS* (communication_name=ID);

microservice_declaration
	: MICROSERVICE (microservice_name=ID) microservice_description*;
		
microservice_description
	: received_message_declaration
	| sended_message_declaration
	| mixin_declaration
		| used_communication
	;

received_message_declaration
	: (RECEIVES (receives=ID)) 
	| (RECEIVES (receives=ID) AND* RESPONDS WITH* (responds=ID));

sended_message_declaration
	: SENDS (sends=ID);

mixin_declaration 
	: LIKE (like_microservice=ID);

used_communication
	: USING COMMUNICATION* (communication_name=ID);

message_declaration
	: MESSAGE CLASS (message_name=ID) message_description*;

message_description
	: USING NAMESPACE (namespace=ID);

COMMUNICATION 
		: 'communication';
DEFAULT	: 'default';
CLASS 	: 'class';
MESSAGE : 'message';
IS 	: 'is';
SENDS 	: 'sends';
LIKE 	: 'like';
AND	: 'and';
WITH    : 'with';

NAMESPACE 
	: 'namespace';

MICROSERVICE 
	: 'microservice';

USING	: 'using';

RECEIVES 
	: 'receives';
RESPONDS 
	: 'responds';

WS: [ \n\t\r]+ -> skip;

LETTER  : ('a'..'z'|'A'..'Z');

ID : ID_ | (ID_'.'ID_);
ID_      : ('a'..'z'|'A'..'Z'|'_') ('a'..'z'|'A'..'Z'|'0'..'9'|'_')*;
INT     : '0'..'9'+;
COMMENT
		:   '//' ~('\n'|'\r')* '\r'? '\n';