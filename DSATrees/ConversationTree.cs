using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATrees
{
    public class ConversationTree
    {
        public ConversationNode root;

        public ConversationNode InsertAfter(string phrase, 
                                        string NextPhrase)
        {
            ConversationNode found = Find(root, phrase);
            if (found!= null)
            {
                ConversationNode newNode = new ConversationNode(NextPhrase, null);
                found.children.Add(newNode);
                return newNode;
            }
            return null;
        }

        public ConversationNode Find(ConversationNode current, string Phrase)
        {
            if (current != null)
            {
                if (current.phrase == Phrase)
                {
                    return current;
                }
                else if (current.children.Count() > 0)
                {
                    // Use LINQ to Check current level childern for the Phrase
                    ConversationNode found = current.children
                                   .FirstOrDefault(c => c.phrase == Phrase);
                    // if found at this level then we are done
                    if (found != null)
                        return found;
                    else
                        // look to each of the children
                        foreach (ConversationNode node in current.children)
                            return Find(node, Phrase);
                }
                
            }
            return null;
        }

        public void TraverseTree(ConversationNode current, 
                                        int level)
        {
            if(current != null)
            {
                Console.WriteLine("Level {0} {1}"
                        ,level.ToString(), current.phrase);
            }
            level++;
            foreach (var child in current.children)
            {
                TraverseTree(child, level);
            }
        }
        public ConversationNode ChooseChild(ConversationNode current)
        {
            int i = 0;
            foreach (ConversationNode answer in current.children)
            {
                Console.WriteLine("Your Choices {0} {1}", i++, answer.phrase);
            }
            if ((i = Int32.Parse(Console.ReadLine())) <= current.children.Count - 1)
                return (current.children[i]);
            return null;
        }

        public string manageConversation(ConversationNode current)
        {
            if(current != null)
            {
                if (current.children.Count > 0)
                    return manageConversation(ChooseChild(current));
                else return current.phrase;
            }
            return string.Empty;
        }
    }
    
    public class ConversationNode
    {
        public List<ConversationNode> children = new List<ConversationNode>();
        public string phrase;

        
        public ConversationNode(string Phrase,
                        List<string> childPhrases)
        {
            phrase = Phrase;
            if (childPhrases != null)
            {
                foreach (var p in childPhrases)
                {
                    children.Add(new ConversationNode(p, null));
                }
            }
        }

        
    }
}
