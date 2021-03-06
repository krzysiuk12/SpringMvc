﻿using SpringMvc.Models.DataGenerator.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class BookTypeGeneratorService : IBookTypeGeneratorService
    {
        #region Data
        private string[] bookTitles = new string[] {    "James and the Giant Peach", "Dead in the Family", "House of Illusions", "Scroll of Saqqara", "Volume Two: The Oasis", "Volume Three: The Horus Road", "Rose Daughter", "The Alton Gift", "Behold the Man", "Rama the Steadfast",
                                                        "Writers Between the Covers", "Looking for Palestine", "The Man from Mars", "Charles Dickens", "Who Was Dracula?", "The Entertainer", "To Have and Have Another", "Life After Death", "The Voice Is All", "Every Love Story Is a Ghost Story",
                                                        "Now and Then", "Double Jeopardy", "Spare Change", "Plague Ship", "The Faithful Spy", "Three in Death", "World Without End", "Skeleton Coast", "The Sisters", "Black Wind",
                                                        "The Black Hills", "Ralph Compton The Cheyenne Trail", "The Gunsmith 389", "Backlands", "Slocum 423", "Longarm 426", "The Lawman: Trackdown", "Slocum 422", "Longarm 425", "Gunsmith 388",
                                                        "Tales from 1,001 Nights", "Frostbite", "The Wizard of Oz", "Oliver Twist", "Treasure Island", "Moby-Dick", "Who Would Have Thought It?", "Tom Clancy's EndWar", "King Solomon's Mines", "The Faithful Spy",
                                                        "No Way Back", "On Tangled Paths", "The Jungle Books", "David Copperfield", "Vainglory", "Childhood; Boyhood; Youth", "Persuasion", "The Promised Land", "The Phantom of the Opera", "Northanger Abbey",
                                                        "Cell", "On Such a Full Sea", "Supervolcano: Things Fall Apart", "Darklove", "The Accidental Werewolf 2: Something About Harry", "Undressing Mr. Darcy", "Saving Grace", "Unrestrained", "Twisted", "Helen in Love",
                                                        "Mark of the Lion", "Black Arrow", "China Bayles' Book of Days", "Mrs. Jeffries and the Silent Knight", "The Oxford Murders", "Fear on Friday", "A German Requiem", "The Right Madness", "A Deadly Yarn", "Murder of a Real Bad Boy",
                                                        "The Signature of All Things", "The Spymistress", "Seven Deadlies", "Peaches for Father Francis", "Dark Witch", "The Spirit Keeper", "Lucianna", "Colters' Gift", "Because We Belong", "Strip Search",
                                                        "Iron Winter", "The Clone Assassin", "Black Heart", "Starhawk", "Kicking It", "Assassin's Creed: Black Flag", "Kris Longknife: Mutineer", "Stone Spring", "Troubled Waters", "The Clone Republic" };

        private string[] bookAuthors = new string[] {   "Roald Dahl", "Charlaine Harris", "Pauline Gedge", "Pauline Gedge", "Pauline Gedge", "Pauline Gedge", "Robin McKinley", "Marion Zimmer Bradley", "Michael Moorcock", "Mary Brockington",
                                                        "Joni Rendon", "Najla Said", "Fred Nadis", "Claire Tomalin", "Jim Steinmeyer", "Margaret Talbot", "Philip Greene", "Damien Echols", "Joyce Johnson", "D. T. Max",                                                    
                                                        "Robert B. Parker", "Catherine Coulter", "Sunny Randall", "Jack Du Brul", "Alex Berenson", "J. D. Robb", "Ken Follett", "Jack Du Brul", "Robert Littell", "Dirk Cussler",
                                                        "Rod Thompson", "Ralph Compton", "J. R. Roberts", "Michael McGarrity", "Jake Logan", "Tabor Evans", "Tabor Evans", "Lyle Brandt", "Jake Logan", "J. R. Roberts",
                                                        "Anonymous", "Leigh Dragoon", "Rachell Sumpter", "Philip Horne", "Robert Louis Stevenson", "Tony Millionaire", "Amelia Maria de la Luz Montes", "David Michaels", "H. Rider Haggard", "Alex Berenson",
                                                        "Theodor Fontane", "Theodor Fontane", "Rudyard Kipling", "Charles Dickens", "Ronald Firbank", "Leo Tolstoy", "Jane Austen", "Mary Antin", "Gaston Leroux", "Jane Austen",
                                                        "Robin Cook", "Chang-rae Lee", "Harry Turtledove", "Elle Jasper", "Dakota Cassidy", "Karen Doornebos", "Lee Smith", "Joey W. Hill", "Laura K. Curtis", "Rosie Sultan",
                                                        "Suzanne Arruda", "I. J. Parker", "Susan Wittig Albert", "Emily Brightwell", "Guillermo Martinez, Sonia Soto", "Ann Purser", "Philip Kerr", "James Crumley", "Maggie Sefton", "Denise Swanson",
                                                        "Elizabeth Gilbert", "Jennifer Chiaverini", "Gigi Levangie", "Joanne Harris", "Nora Roberts", "K. B. Laugheed", "Bertrice Small", "Maya Banks", "Beth Kery", "Shayla Black",
                                                        "Stephen Baxter", "Steven L. Kent", "Christina Henry", "Jack McDevitt", "Kalayna Price", "Oliver Bowden", "Mike Shepherd", "Stephen Baxter", "Sharon Shinn", "Steven L. Kent" };
        
        private string[] categoryNames = new string[] { "Fantasy", 
                                                        "Fiction/Literary", 
                                                        "Suspense and Thrillers", 
                                                        "Western", 
                                                        "Action and Adventure", 
                                                        "Classics", 
                                                        "General", 
                                                        "Mystery", 
                                                        "Romance", 
                                                        "Science Fiction" };

        private string[] bookImagesLinks = new string[] {   "/Images/Books/Fantasy_JamesandtheGiantPeach.png",
                                                            "/Images/Books/Fantasy_DeadintheFamily.png", 
                                                            "/Images/Books/Fantasy_HouseofIllusions.png", 
                                                            "/Images/Books/Fantasy_ScrollofSaqqara.png", 
                                                            "/Images/Books/Fantasy_VolumeTwoTheOasis.png", 
                                                            "/Images/Books/Fantasy_VolumeThreeTheHorusRoad.png",
                                                            "/Images/Books/Fantasy_RoseDaughter.png",
                                                            "/Images/Books/Fantasy_TheAltonGift.png",  
                                                            "/Images/Books/Fantasy_BeholdtheMan.png", 
                                                            "/Images/Books/Fantasy_RamatheSteadfast.png", 

                                                            "/Images/Books/Fiction_WritersBetweentheCovers.png",
                                                            "/Images/Books/Fiction_LookingforPalestine.png", 
                                                            "/Images/Books/Fiction_TheManfromMars.png",  
                                                            "/Images/Books/Fiction_CharlesDickens.png",
                                                            "/Images/Books/Fiction_WhoWasDracula.png", 
                                                            "/Images/Books/Fiction_TheEntertainer.png", 
                                                            "/Images/Books/Fiction_ToHaveandHaveAnother.png",
                                                            "/Images/Books/Fiction_LifeAfterDeath.png", 
                                                            "/Images/Books/Fiction_TheVoiceIsAll.png", 
                                                            "/Images/Books/Fiction_EveryLoveStoryisaGhostStory.png", 

                                                            "/Images/Books/Suspense_NowandThen.png",
                                                            "/Images/Books/Suspense_DoubleJeopardy.png", 
                                                            "/Images/Books/Suspense_SpareChange.png", 
                                                            "/Images/Books/Suspense_PlagueShip.png", 
                                                            "/Images/Books/Suspense_TheFaithfulSpy.png", 
                                                            "/Images/Books/Suspense_ThreeinDeath.png",
                                                            "/Images/Books/Suspense_WorldWithoutEnd.png", 
                                                            "/Images/Books/Suspense_SkeletonCoast.png", 
                                                            "/Images/Books/Suspense_TheSisters.png", 
                                                            "/Images/Books/Suspense_BlackWind.png", 

                                                            "/Images/Books/Western_TheBlackHills.png",
                                                            "/Images/Books/Western_RalphComptonTheCheyenneTrail.png",
                                                            "/Images/Books/Western_TheGunsmith389.png",  
                                                            "/Images/Books/Western_Backlands.png",
                                                            "/Images/Books/Western_Slocum423.png",
                                                            "/Images/Books/Western_Longarm426.png",
                                                            "/Images/Books/Western_TheLawmanTrackdown.png",   
                                                            "/Images/Books/Western_Slocum422.png",  
                                                            "/Images/Books/Western_Longarm425.png",
                                                            "/Images/Books/Western_Gunsmith388.png",

                                                            "/Images/Books/Action_Talesfrom1001Nights.png", 
                                                            "/Images/Books/Action_Frostbite.png",
                                                            "/Images/Books/Action_TheWizardofOz.png", 
                                                            "/Images/Books/Action_OliverTwist.png",
                                                            "/Images/Books/Action_TreasureIsland.png", 
                                                            "/Images/Books/Action_MobyDick.png",
                                                            "/Images/Books/Action_WhoWouldHaveThoughtIt.png",
                                                            "/Images/Books/Action_TomClancysEndWar.png",
                                                            "/Images/Books/Action_KingSolomonsMines.png", 
                                                            "/Images/Books/Action_TheFaithfulSpy.png",

                                                            "/Images/Books/Classics_NoWayBack.png", 
                                                            "/Images/Books/Classics_OnTangledPaths.png",
                                                            "/Images/Books/Classics_TheJungleBooks.png",
                                                            "/Images/Books/Classics_DavidCopperfield.png",
                                                            "/Images/Books/Classics_Vainglory.png",    
                                                            "/Images/Books/Classics_ChildhoodBoyhoodYouth.png", 
                                                            "/Images/Books/Classics_Persuasion.png",
                                                            "/Images/Books/Classics_ThePromisedLand.png", 
                                                            "/Images/Books/Classics_ThePhantomoftheOpera.png", 
                                                            "/Images/Books/Classics_NorthangerAbbey.png", 


                                                            "/Images/Books/General_Cell.png", 
                                                            "/Images/Books/General_OnSuchaFullSea.png",
                                                            "/Images/Books/General_Supervolcano.png",  
                                                            "/Images/Books/General_Darklove.png",
                                                            "/Images/Books/General_TheAccidentalWerewolf2.png",
                                                            "/Images/Books/General_UndressingMrDarcy.png",
                                                            "/Images/Books/General_SavingGrace.png", 
                                                            "/Images/Books/General_Unrestrained.png",
                                                            "/Images/Books/General_Twisted.png",     
                                                            "/Images/Books/General_HeleninLove.png",

                                                            "/Images/Books/Mystery_MarkoftheLion.png",
                                                            "/Images/Books/Mystery_BlackArrow.png",
                                                            "/Images/Books/Mystery_ChinaBaylesBookofDays.png",
                                                            "/Images/Books/Mystery_MrsJeffriesandtheSilentKnight.png",
                                                            "/Images/Books/Mystery_TheOxfordMurders.png",
                                                            "/Images/Books/Mystery_FearonFriday.png", 
                                                            "/Images/Books/Mystery_AGermanRequiem.png",
                                                            "/Images/Books/Mystery_TheRightMadness.png",   
                                                            "/Images/Books/Mystery_ADeadlyYarn.png", 
                                                            "/Images/Books/Mystery_MurderofaRealBadBoy.png", 

                                                            "/Images/Books/Romance_TheSignatureofallThings.png",
                                                            "/Images/Books/Romance_TheSpymistress.png",
                                                            "/Images/Books/Romance_SevenDeadlies.png",
                                                            "/Images/Books/Romance_PeachesforFatherFrancis.png",    
                                                            "/Images/Books/Romance_DarkWitch.png",
                                                            "/Images/Books/Romance_TheSpiritKeeper.png", 
                                                            "/Images/Books/Romance_Lucianna.png",
                                                            "/Images/Books/Romance_ColtersGift.png", 
                                                            "/Images/Books/Romance_BecauseWeBelong.png", 
                                                            "/Images/Books/Romance_StripSearch.png", 

                                                            "/Images/Books/SciFi_IronWinter.png",
                                                            "/Images/Books/SciFi_TheCloneAssassin.png", 
                                                            "/Images/Books/SciFi_BlackHeart.png", 
                                                            "/Images/Books/SciFi_KickingIt.png",
                                                            "/Images/Books/SciFi_Starhawk.png",
                                                            "/Images/Books/SciFi_AssassinsCreedBlackFlag.png", 
                                                            "/Images/Books/SciFi_KrisLongknigeMutineer.png", 
                                                            "/Images/Books/SciFi_StoneSpring.png", 
                                                            "/Images/Books/SciFi_TroubledWaters.png", 
                                                            "/Images/Books/SciFi_TheCloneRepublic.png" };
        #endregion

        private Random random = new Random();

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
                books.Add(new BookType()
                {
                    Title = bookTitles[index],
                    Authors = bookAuthors[index],
                    Category = categories.ElementAt((int)Math.Floor((double)(index / categories.Count))),
                    Price = new Decimal(random.NextDouble() * 100),
                    QuantityMap = quantityMaps.ElementAt(index),
                    Image = new BookImage() { URL = bookImagesLinks[index] }
                });
            }
            return books;
        }

        private List<BookImage> GenerateBookImages(int index)
        {
            List<BookImage> images = new List<BookImage>();
            images.Add(new BookImage()
            {
                URL = bookImagesLinks[index]
            });
            return images;
        }
    }
}