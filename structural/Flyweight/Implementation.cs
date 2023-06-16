namespace Flyweight
{
    internal class Implementation
    {
        internal interface ICharacter
        {
            void Draw(string fontFamily, int fontSize);
        }

        internal class CharacterA : ICharacter
        {
            private char actualCharacter = 'a';
            private string fontFamily = string.Empty;
            private int fontSize;

            public void Draw(string fontFamily, int fontSize)
            {
                this.fontFamily = fontFamily;
                this.fontSize = fontSize;
                Console.WriteLine($"Drawing {actualCharacter}, {fontFamily} {fontSize}");
            }
        }

        internal class CharacterB : ICharacter
        {
            private char actualCharacter = 'b';
            private string fontFamily = string.Empty;
            private int fontSize;

            public void Draw(string fontFamily, int fontSize)
            {
                this.fontFamily = fontFamily;
                this.fontSize = fontSize;
                Console.WriteLine($"Drawing {actualCharacter}, {fontFamily} {fontSize}");
            }
        }

        internal class CharacterFactory
        {
            private readonly Dictionary<char, ICharacter> characters = new();

            public ICharacter GetCharacter(char characterId)
            {
                if (characters.ContainsKey(characterId))
                {
                    Console.WriteLine("Character reuse");
                    return characters[characterId];
                }

                Console.WriteLine("Character construction");
                switch (characterId)
                {
                    case 'a':
                        characters[characterId] = new CharacterA(); 
                        return characters[characterId];
                    case 'b':
                        characters[characterId] = new CharacterB();
                        return characters[characterId];
                    default:
                        break;
                }

                return null;
            }

            public ICharacter CreateParagraph(List<ICharacter> characters, int location) =>
                 new Paragraph(characters, location);
        }

        internal class Paragraph : ICharacter
        {
            private int location;
            private List<ICharacter> characters = new();

            public Paragraph(List<ICharacter> characters, int location)
            {
                this.characters = characters;
                this.location = location;
            }

            public void Draw(string fontFamily, int fontSize)
            {
                Console.WriteLine($"Drawing in paragraph at location {location}");
                foreach (var character in characters)
                {
                    character.Draw(fontFamily, fontSize);
                }
            }
        }
    }
}
