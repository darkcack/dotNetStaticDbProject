using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBvize.Models
{
    public static class VeriTabani
    {
        private static List<Movie> _filmListesi;  // Film Listesi
        private static List<Category> _kategoriListesi; // Film Listesi
        private static List<Comment> _yorumListesi; // Film Listesi

        static VeriTabani()
        {
           // Static Kategori Listesi Ataması
            _kategoriListesi = new List<Category>()
            {
                new Category(){id=1, Name="Aksiyon"},
                 new Category(){id=2, Name="Macera"},
                  new Category(){id=3, Name="Korku"},
                   new Category(){id=4,Name="Komedi"},
                   new Category(){id=5,Name="Dram"}
            };

            // Static Film Listesi Ataması
            _filmListesi = new List<Movie>()
            {
                new Movie(){Year=1972, id=1, Name="The Godfather",Headliner="Al Pacino", Description="The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",category=_kategoriListesi[4],categoryId=5 },
                new Movie(){Year=2003,id=2, Name="LOTR: The Return of The King",Headliner="Elijah Wood", Description="Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",category=_kategoriListesi[1],categoryId=2},
                new Movie(){Year=1999,id=3, Name="Matrix",Headliner="Keanu Reeves", Description="A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers."
                ,category=_kategoriListesi[0],categoryId=1},
                new Movie(){Year=1995,id=4, Name="Seven",Headliner="Brad Pitt", Description="Two detectives, a rookie and a veteran, hunt a serial killer who uses the seven deadly sins as his motives.",category=_kategoriListesi[4],categoryId=5},
                new Movie(){Year=1991,id=5, Name="Terminator 2: Judgment Day",Headliner="Arnold Schwarzenegger", Description="A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her teenage son, John Connor, from a more advanced and powerful cyborg."
,category=_kategoriListesi[0],categoryId=1},
                new Movie(){Year=1979,id=6, Name="Alien",Headliner=" Sigourney Weaver", Description="After a space merchant vessel receives an unknown transmission as a distress call, one of the crew is attacked by a mysterious life form and they soon realize that its life cycle has merely begun."
,category=_kategoriListesi[2],categoryId=3 },
                new Movie(){Year=1985,id=7, Name="Back to the Future",Headliner="Michael J. Fox", Description="Marty McFly, a 17-year-old high school student, is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his close friend, the eccentric scientist Doc Brown."
,category=_kategoriListesi[3],categoryId=4 }


            };

            // Static Yorum Listesi Ataması
            _yorumListesi = new List<Comment>()
            {
                new Comment(){id=1, comment="Bu The Godfather filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=1 },
                new Comment(){id=2, comment="One of the best films of all time, an absolute masterpiece. The Godfather is arguably the best gangster drama as well as setting the standard for cinema.",CommentName="Mert Aktaş",Movieid=1 },
                new Comment(){id=3, comment="Bu LOTR: The Return of The King filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=2 },
                new Comment(){id=4, comment="Wonderful on every level. Love the characters and special effects. One of the biggest, most massive battle scenes ever put on the silver screen. A great end to a monumental epic.",CommentName="Mert Aktaş",Movieid=2 },
                new Comment(){id=5, comment="Bu Matrix filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=3 },
                new Comment(){id=6, comment="The first time i watched this, i was absolutely amazed with the concept of it. The action is just so amazing to watch. I've seen this film 3 times and each time it just gets better. If you like sci fi action films then this is the film for you.",CommentName="Mert Aktaş",Movieid=3 },
                new Comment(){id=7, comment="Bu Seven filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=4 },
                new Comment(){id=8, comment=" I have seen this film like a thousand times and every time I watch it again it's as disturbing as the first time. It's always intriguing from start till finish. This is one of the best stories ever told on screen. 10/10 for this motion picture, it's a true art. A must watch.",CommentName="Mert Aktaş",Movieid=4 },
                new Comment(){id=9, comment="Bu Terminator 2: Judgment Day filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=5 },
                new Comment(){id=10, comment="A classic and belongs in the top tier of action films. The action sequences are exciting and plain awesome. Involving an arsenal of weapons, a Harley-Davidson and Arnold Schwarzenegger, action movies don't get better than this.",CommentName="Mert Aktaş",Movieid=5 },
                new Comment(){id=11, comment="Bu Alien filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=6 },
                new Comment(){id=12, comment="Best aged sci-fi film. Such a classic and well-loved film? Can't praise it enough.",CommentName="Mert Aktaş",Movieid=6 },
                new Comment(){id=13, comment="Bu Back to the Future filmine ilk yorumum",CommentName="Mert Aktaş",Movieid=7 },
                new Comment(){id=14, comment="It's a teenage movie, it's a comedy, it's a science fiction adventure... and there's nothing better.",CommentName="Mert Aktaş",Movieid=7 }
            };

            //her kategoriye filmleri yukle
            foreach (var cat in _kategoriListesi)
            {
                foreach (var mov in _filmListesi)
                {
                    if (cat.id == mov.category.id)
                    {
                        cat.movies.Add(mov);
                    }
                }
            }

            // her filme yorumları yukle
            foreach(var mov in _filmListesi)
            {
                foreach(var com in _yorumListesi)
                {
                    if(mov.id== com.Movieid)
                    {
                        mov.Comment.Add(com);
                    }
                }
            }


        }

        public static void YorumEkle(Comment comment)
        {
            comment.id = (_yorumListesi[_yorumListesi.Count - 1].id) + 1;  // Ekli Olan En Yüksek id'ye 1 ekleme 
            _yorumListesi.Add(comment);
            foreach(var item in _filmListesi)
            {
                if (comment.Movieid == item.id)
                {
                    item.Comment.Add(comment);
                }

            }
            _yorumListesi.Add(comment);
        }

        public static void YorumSil(int commentid)
        {
            Comment com = null;
            foreach(var item in _yorumListesi)
            {
                if (item.id == commentid)
                {
                    com = item;
                }
            }

            _yorumListesi.Remove(com);

            foreach (var item in _filmListesi)
            {
                if (com.Movieid == item.id)
                {
                    item.Comment.Remove(com);
                }

            }
        }

        public static string KategoriBul(int id)
        {
            id--;
            return _kategoriListesi[id].Name.ToString();
        }

        public static int YorumlaBul(int commentid)
        {
            int filmid = 0;
            foreach(var item in _yorumListesi)
            {
                if(commentid== item.id)
                {
                    filmid = item.Movieid;
                }
                

            }
            return filmid;
        }

        public static List<Category> KategoriListele
        {
            get { return _kategoriListesi; }
        }

        public static void KategoriEkle(Category category)
        {

            category.id = (_kategoriListesi[_kategoriListesi.Count - 1].id) + 1;  // Ekli Olan En Yüksek id'ye 1 ekleme 



            _kategoriListesi.Add(category);
        }

        public static void KategoriSil(int categoryid)
        {
            Category kategori= null;
            foreach (var item in _kategoriListesi)
            {
                if (item.id == categoryid)
                {
                    kategori = item;
                }
            }
            _kategoriListesi.Remove(kategori);
        }

        public static List< Movie> KategoriDetay(int kategoriid)
        {
            List<Movie> _filmList =null;

            foreach (var item in _kategoriListesi)
            {
                if (item.id == kategoriid)
                {
                    return item.movies;
                }
            }
            return _filmList;
        }


        public static List<Movie> FilmListele
        {
            get { return _filmListesi; }
        }


        public static void FilmEkle(Movie movie)
        {
            foreach (var cat in _kategoriListesi)
            {
                if (movie.categoryId == cat.id)
                {
                    movie.category = cat;
                }
            }
            if (movie.id == 0)
            {
                movie.id = (_filmListesi[_filmListesi.Count - 1].id) + 1;

            }




            _filmListesi.Add(movie);

            //anla calis
            foreach(var item in _kategoriListesi)
            {
                if (item.id == movie.category.id)
                {
                    item.movies.Add(movie);
                }
            }

            
        }
        

        public static void FilmSil(int movieid)
        {
            Movie film = null;
            foreach (var item in _filmListesi)
            {
                if (item.id == movieid)
                {
                    film= item;
                }
            }
            foreach(var tyy in _kategoriListesi)
            {
                tyy.movies.Remove(film);
            }
            _filmListesi.Remove(film);
        }

        public static void FilmGuncelle(Movie movie)
        {
            int id = movie.id;
            VeriTabani.FilmSil(id);
            VeriTabani.FilmEkle(movie);

            
        }
        public static Movie FilmDetay(int movieid)
        {
            Movie film = null;
            foreach (var item in _filmListesi)
            {
                if (item.id == movieid)
                {
                    film = item;
                }
            }
            return film;
        }

        

    }
}