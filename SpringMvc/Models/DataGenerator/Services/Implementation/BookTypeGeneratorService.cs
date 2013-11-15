using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class BookTypeGeneratorService
    {
        #region Data
        private string[] bookTitles = new string[] {    "James and the Giant Peach", "Dead in the Family", "House of Illusions", "Scroll of Saqqara", "Volume Two: The Oasis", "Volume Three: The Horus Road", "Rose Daughter", "The Alton Gift", "Behold the Man", "Rama the Steadfast",
                                                        "Writers Between the Covers", "Looking for Palestine", "The Man from Mars", "The Faraway Nearby", "Who Was Dracula?", "The Entertainer", "To Have and Have Another", "Life After Death", "The Voice Is All", "Every Love Story Is a Ghost Story",
                                                        "Now and Then", "Double Jeopardy", "Spare Change", "Plague Ship", "The Faithful Spy", "Three in Death", "World Without End", "Skeleton Coast", "The Sisters", "Black Wind",
                                                        "The Black Hills", "Ralph Compton The Cheyenne Trail", "The Gunsmith 389", "A Serpent's Tooth", "Slocum 423", "Longarm 426", "The Lawman: Trackdown", "Slocum 422", "Longarm 425", "Gunsmith 388",
                                                        "Tales from 1,001 Nights", "Frostbite", "The Wizard of Oz", "Oliver Twist", "Treasure Island", "Moby-Dick", "Who Would Have Thought It?", "Tom Clancy's EndWar", "King Solomon's Mines", "The Faithful Spy",
                                                        "No Way Back", "On Tangled Paths", "The Jungle Books", "David Copperfield", "Vainglory", "Childhood; Boyhood; Youth", "Tales from 1,001 Nights", "The Promised Land", "The Phantom of the Opera", "Northanger Abbey",                                                                "", "", "", "", "", "", "", "", "", "",
                                                        "Cell", "On Such a Full Sea", "Supervolcano: Things Fall Apart", "Darklove", "The Accidental Werewolf 2: Something About Harry", "Undressing Mr. Darcy", "Saving Grace", "Unrestrained", "City of Lost Dreams", "Helen in Love",
                                                        "Mark of the Lion", "Black Arrow", "China Bayles' Book of Days", "Mrs. Jeffries and the Silent Knight", "The Oxford Murders", "Fear on Friday", "A German Requiem", "The Right Madness", "A Deadly Yarn", "Murder of a Real Bad Boy",
                                                        "The Signature of All Things", "The Spymistress", "Seven Deadlies", "Peaches for Father Francis", "Dark Witch", "The Spirit Keeper", "Lucianna", "Helen in Love", "Because We Belong", "Strip Search",
                                                        "Iron Winter", "The Clone Assassin", "Black Heart", "Starhawk", "Kicking It", "Assassin's Creed: Black Flag", "Kris Longknife: Mutineer", "Stone Spring", "Troubled Waters", "The Clone Republic" };
        private string[] bookAuthors = new string[] {   "Roald Dahl", "Charlaine Harris", "Pauline Gedge", "Pauline Gedge", "Pauline Gedge", "Pauline Gedge", "Robin McKinley", "Marion Zimmer Bradley", "Michael Moorcock", "Mary Brockington",
                                                        "Joni Rendon", "Najla Said", "Fred Nadis", "Rebecca Solnit", "Jim Steinmeyer", "Margaret Talbot", "Philip Greene", "Damien Echols", "Joyce Johnson", "D. T. Max",                                                    
                                                        "Robert B. Parker", "Catherine Coulter", "Sunny Randall", "Jack Du Brul", "Alex Berenson", "J. D. Robb", "Ken Follett", "Jack Du Brul", "Robert Littell", "Dirk Cussler",
                                                        "Rod Thompson", "Ralph Compton", "J. R. Roberts", "Craig Johnson", "Jake Logan", "Tabor Evans", "Tabor Evans", "Lyle Brandt", "Jake Logan", "J. R. Roberts",
                                                        "Anonymous", "Leigh Dragoon", "Rachell Sumpter", "Philip Horne", "Robert Louis Stevenson", "Tony Millionaire", "Amelia Maria de la Luz Montes", "David Michaels", "H. Rider Haggard", "Alex Berenson",
                                                        "Theodor Fontane", "Theodor Fontane", "Rudyard Kipling", "Charles Dickens", "Ronald Firbank", "Leo Tolstoy", "Anonymous", "Mary Antin", "Gaston Leroux", "Jane Austen",
                                                        "Robin Cook", "Chang-rae Lee", "Harry Turtledove", "Elle Jasper", "Dakota Cassidy", "Karen Doornebos", "Lee Smith", "Joey W. Hill", "Magnus Flyte", "Rosie Sultan",
                                                        "Suzanne Arruda", "I. J. Parker", "Susan Wittig Albert", "Emily Brightwell", "Guillermo Martinez, Sonia Soto", "Ann Purser", "Philip Kerr", "James Crumley", "Maggie Sefton", "Denise Swanson",
                                                        "Elizabeth Gilbert", "Jennifer Chiaverini", "Gigi Levangie", "Joanne Harris", "Nora Roberts", "K. B. Laugheed", "Bertrice Small", "Rosie Sultan", "Beth Kery", "Shayla Black",
                                                        "Stephen Baxter", "Steven L. Kent", "Christina Henry", "Jack McDevitt", "Kalayna Price", "Oliver Bowden", "Mike Shepherd", "Stephen Baxter", "Sharon Shinn", "Steven L. Kent" };
        private string[] categoryNames = new string[] { "Fantasy", 
                                                        "Fiction/Literary", 
                                                        "Suspense & Thrillers", 
                                                        "Western", 
                                                        "Action & Adventure", 
                                                        "Classics", 
                                                        "General", 
                                                        "Mystery", 
                                                        "Romance", 
                                                        "Science Fiction" };
        private Random random = new Random();
        #endregion

        public List<Category> GenerateCategories() 
        {
            List<Category> categories = new List<Category>();
            foreach(string categoryName in categoryNames)
            {
                categories.Add(new Category() { Name = categoryName });
            }
            return categories;
        }

        public List<QuantityMap> GenerateQuantityMaps() 
        {
            List<QuantityMap> quantityMap = new List<QuantityMap>();
            foreach(string bookTitle in bookTitles)
            {
                quantityMap.Add(new QuantityMap() { Quantity = random.Next(500) + 1});
            }
            return quantityMap;
        }

        public List<BookType> GenerateBooks(List<Category> categories, List<QuantityMap> quantityMaps)
        {
            List<BookType> books = new List<BookType>();
            for(int index = 0; index < bookTitles.Length; index++) 
            {
                BookType newBook = new BookType()
                {
                    Title = bookTitles[index],
                    Authors = bookAuthors[index],
                    Category = categories.ElementAt((int)Math.Floor((double)(index / categories.Count))),
                    Price = new Decimal(random.NextDouble() * 100),
                    QuantityMap = quantityMaps.ElementAt(index)
                };
            }
            return books;
        }
    }
}