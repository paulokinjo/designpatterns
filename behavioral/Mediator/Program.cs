using static Mediator.Implementation;

Console.Title = "Mediator";

TeamChatRoom teamChatRoom = new TeamChatRoom();

var m1 = new Lawyer("m1");
var m2 = new Lawyer("m2");
var m3 = new AccountManager("m3");
var m4 = new AccountManager("m4");
var m5 = new AccountManager("m5");

teamChatRoom.Register(m1);
teamChatRoom.Register(m2);
teamChatRoom.Register(m3);
teamChatRoom.Register(m4);
teamChatRoom.Register(m5);

m1.Send("m5", "THis is a private message to you");

m3.Send("Hi you all");