using static Flyweight.Implementation;

Console.Title = "Flyweight";

var aBunchOfCharacters = "abba";

var characterFactory = new CharacterFactory();

var characterObject = characterFactory.GetCharacter(aBunchOfCharacters[0]);
characterObject?.Draw("Arial", 12);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[1]);
characterObject?.Draw("Trebuchet MS", 14);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[2]);
characterObject?.Draw("Times new Roman", 16);

characterObject = characterFactory.GetCharacter(aBunchOfCharacters[3]);
characterObject?.Draw("Comic Sans MS", 18);

var paragraph = characterFactory.CreateParagraph(new List<ICharacter>() { characterObject }, 1);

paragraph.Draw("Lucinda", 12);
