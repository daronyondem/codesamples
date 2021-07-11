using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataConversion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Dialogue original data grabbed from 
            //https://github.com/UCSD-AI4H/COVID-Dialogue/blob/master/COVID-Dialogue-Dataset-English.txt
            Console.WriteLine("Starting!");
            TagFound latestFound = TagFound.None;

            var newDialogue = new Dialogue();
            List<Dialogue> dialogueList = new List<Dialogue>();
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"COVID-Dialogue-Dataset-English.txt");
            while ((line = file.ReadLine()) != null)
            {                
                if (line.Contains("id="))
                {
                    latestFound = TagFound.Id;
                    dialogueList.Add(newDialogue);

                    newDialogue = new Dialogue();
                    int Id;
                    bool foundId = int.TryParse(line.Replace("id=", ""), out Id);
                    newDialogue.Id = Id;
                }
                else if (line == "Dialogue")
                {
                    latestFound = TagFound.Dialogue;
                }
                else if (line == "Description")
                {
                    latestFound = TagFound.Description;
                }
                else
                {
                    if (latestFound == TagFound.Description)
                    {
                        newDialogue.Description += line + Environment.NewLine;
                    }
                    else if (latestFound == TagFound.Dialogue)
                    {
                        newDialogue.DialogueText += line + Environment.NewLine;
                    }
                }
            }

            file.Close();

            foreach (var item in dialogueList)
            {
                using FileStream createStream = File.Create($"dialogue-{item.Id}.txt");
                await JsonSerializer.SerializeAsync(createStream, item);
            }           

            System.Console.ReadLine();
        }
    }

    enum TagFound
    {
        Id,
        Description,
        Dialogue,
        None
    }
    public class Dialogue
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DialogueText { get; set; }
    }
}
