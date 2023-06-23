namespace Mediator
{
    internal class Implementation
    {
        internal abstract class TeamMember
        {
            private IChatRoom? chatRoom;
            public string Name { get; set; }

            protected TeamMember(string name) => Name = name;

            public void SetChatRoom(IChatRoom chatRoom) => this.chatRoom = chatRoom;

            public void Send(string message) => chatRoom?.Send(Name, message);
            public void Send(string to, string message) => chatRoom?.Send(Name, to, message);
            public virtual void Receive(string from, string message) => Console.WriteLine($"Message {from} to {Name}: {message}");
        }

        internal interface IChatRoom
        {
            void Register(TeamMember teamMember);
            void Send(string from, string message);
            void Send(string from, string to, string message);

        }

        internal class Lawyer : TeamMember
        {
            public Lawyer(string name) : base(name) 
            {
                
            }

            public override void Receive(string from, string message)
            {
                Console.WriteLine($"{nameof(Lawyer)} {Name} received: ");
                base.Receive(from, message);
            }
        }

        internal class AccountManager : TeamMember
        {
            public AccountManager(string name) : base(name)
            {

            }

            public override void Receive(string from, string message)
            {
                Console.WriteLine($"{nameof(AccountManager)} {Name} received: ");
                base.Receive(from, message);
            }
        }

        internal class TeamChatRoom : IChatRoom
        {
            private readonly Dictionary<string, TeamMember> teamMembers = new();

            public void Register(TeamMember teamMember)
            {
                teamMember.SetChatRoom(this);
                if (!teamMembers.ContainsKey(teamMember.Name))
                {
                    teamMembers.Add(teamMember.Name, teamMember);
                }
            }

            public void Send(string from, string message)
            {
                foreach (var teamMember in teamMembers.Values)
                {
                    teamMember.Receive(from, message);
                }
            }

            public void Send(string from, string to, string message)
            {
                var teamMember = teamMembers[to];
                teamMember?.Receive(from, message);
            }
        }

    }
}
