using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Mis333ksp18Group17.DAL;
using Mis333ksp18Group17.Models;


namespace Mis333ksp18Group17.Migrations
{
    public class MovieData
    {
        public void SeedMovies(AppDbContext db)
        {
     
           
            Movie m0 = new Movie();
            m0.MovieNum = 3001;
            m0.Title = "42nd Street";
            m0.Overview = "A producer puts on what may be his last Broadway show, and at the last moment a chorus girl has to replace the star.";
            m0.ReleaseDate = new DateTime(1933, 2, 2);
            m0.Revenue = 2281000;
            m0.Runtime = 89;
            m0.Tagline = "OK. Say, Jones and Barry are doin' a show! - That's great. Jones and Barry are doin' a show.";
            m0.MPAARating = enumMPAARating.Unrated;
            m0.Actors = "Warner Baxter, Bebe Daniels, George Brent, Ruby Keeler, Guy Kibbee, Una Merkel";
            db.Movies.AddOrUpdate(m => m.Title, m0);
            db.SaveChanges();


            m0 = db.Movies.FirstOrDefault(m => m.MovieNum == m0.MovieNum);
            m0.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m0.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m0.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m1 = new Movie();
            m1.MovieNum = 3002;
            m1.Title = "It Happened One Night";
            m1.Overview = "Ellie Andrews has just tied the knot with society aviator King Westley when she is whisked away to her father's yacht and out of King's clutches. Ellie jumps ship and eventually winds up on a bus headed back to her husband. Reluctantly she must accept the help of out-of- work reporter Peter Warne. Actually, Warne doesn't give her any choice: either she sticks with him until he gets her back to her husband, or he'll blow the whistle on Ellie to her father. Either way, Peter gets what he wants... a really juicy newspaper story!";
            m1.ReleaseDate = new DateTime(1934, 2, 22);
            m1.Revenue = 4500000;
            m1.Runtime = 105;
            m1.Tagline = "TOGETHER... for the first time";
            m1.MPAARating = enumMPAARating.Unrated;
            m1.Actors = "Clark Gable, Claudette Colbert, Walter Connolly, Roscoe Karns, Jameson Thomas, Alan Hale";
            db.Movies.AddOrUpdate(m => m.Title, m1);
            db.SaveChanges();


            m1 = db.Movies.FirstOrDefault(m => m.MovieNum == m1.MovieNum);
            m1.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m1.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m2 = new Movie();
            m2.MovieNum = 3003;
            m2.Title = "Snow White and the Seven Dwarfs";
            m2.Overview = "A beautiful girl, Snow White, takes refuge in the forest in the house of seven dwarfs to hide from her stepmother, the wicked Queen. The Queen is jealous because she wants to be known as \"the fairest in the land,\" and Snow White's beauty surpasses her own.";
            m2.ReleaseDate = new DateTime(1937, 12, 20);
            m2.Revenue = 184925486;
            m2.Runtime = 83;
            m2.Tagline = "The Happiest, Dopiest, Grumpiest, Sneeziest movie of the year.";
            m2.MPAARating = enumMPAARating.G;
            m2.Actors = "Adriana Caselotti, Lucille La Verne, Harry Stockwell, Roy Atwell, Pinto Colvig, Otis Harlan";
            db.Movies.AddOrUpdate(m => m.Title, m2);
            db.SaveChanges();


            m2 = db.Movies.FirstOrDefault(m => m.MovieNum == m2.MovieNum);
            m2.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m2.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m2.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m3 = new Movie();
            m3.MovieNum = 3004;
            m3.Title = "The Wizard of Oz";
            m3.Overview = "Young Dorothy finds herself in a magical world where she makes friends with a lion, a scarecrow and a tin man as they make their way along the yellow brick road to talk with the Wizard and ask for the things they miss most in their lives. The Wicked Witch of the West is the only thing that could stop them.";
            m3.ReleaseDate = new DateTime(1939, 8, 15);
            m3.Revenue = 33754967;
            m3.Runtime = 102;
            m3.Tagline = "We're off to see the Wizard, the wonderful Wizard of Oz!";
            m3.MPAARating = enumMPAARating.PG;
            m3.Actors = "Judy Garland, Frank Morgan, Ray Bolger, Bert Lahr, Jack Haley, Billie Burke";
            db.Movies.AddOrUpdate(m => m.Title, m3);
            db.SaveChanges();


            m3 = db.Movies.FirstOrDefault(m => m.MovieNum == m3.MovieNum);
            m3.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m3.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m3.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m4 = new Movie();
            m4.MovieNum = 3005;
            m4.Title = "Mr. Smith Goes to Washington";
            m4.Overview = "Naive and idealistic Jefferson Smith, leader of the Boy Rangers, is appointed on a lark by the spineless governor of his state. He is reunited with the state's senior senator--presidential hopeful and childhood hero, Senator Joseph Paine. In Washington, however, Smith discovers many of the shortcomings of the political process as his earnest goal of a national boys' camp leads to a conflict with the state political boss, Jim Taylor. Taylor first tries to corrupt Smith and then later attempts to destroy Smith through a scandal.";
            m4.ReleaseDate = new DateTime(1939, 10, 19);
            m4.Revenue = 9600000;
            m4.Runtime = 129;
            m4.Tagline = "Romance, drama, laughter and heartbreak... created out of the very heart and soil of America!";
            m4.MPAARating = enumMPAARating.Unrated;
            m4.Actors = "James Stewart, Jean Arthur, Claude Rains, Edward Arnold, Guy Kibbee, Thomas Mitchell";
            db.Movies.AddOrUpdate(m => m.Title, m4);
            db.SaveChanges();


            m4 = db.Movies.FirstOrDefault(m => m.MovieNum == m4.MovieNum);
            m4.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m4.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m4.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            db.SaveChanges();


            Movie m5 = new Movie();
            m5.MovieNum = 3006;
            m5.Title = "Gone with the Wind";
            m5.Overview = "An American classic in which a manipulative woman and a roguish man carry on a turbulent love affair in the American south during the Civil War and Reconstruction.";
            m5.ReleaseDate = new DateTime(1939, 12, 15);
            m5.Revenue = 400176459;
            m5.Runtime = 238;
            m5.Tagline = "The greatest romance of all time!";
            m5.MPAARating = enumMPAARating.G;
            m5.Actors = "Vivien Leigh, Clark Gable, Olivia de Havilland, Thomas Mitchell, Leslie Howard, Barbara O'Neil";
            db.Movies.AddOrUpdate(m => m.Title, m5);
            db.SaveChanges();


            m5 = db.Movies.FirstOrDefault(m => m.MovieNum == m5.MovieNum);
            m5.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m5.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m6 = new Movie();
            m6.MovieNum = 3007;
            m6.Title = "Casablanca";
            m6.Overview = "In Casablanca, Morocco in December 1941, a cynical American expatriate meets a former lover, with unforeseen complications.";
            m6.ReleaseDate = new DateTime(1942, 11, 26);
            m6.Revenue = 10462500;
            m6.Runtime = 102;
            m6.Tagline = "They had a date with fate in Casablanca!";
            m6.MPAARating = enumMPAARating.PG;
            m6.Actors = "Humphrey Bogart, Ingrid Bergman, Paul Henreid, Claude Rains, Conrad Veidt, Sydney Greenstreet";
            db.Movies.AddOrUpdate(m => m.Title, m6);
            db.SaveChanges();


            m6 = db.Movies.FirstOrDefault(m => m.MovieNum == m6.MovieNum);
            m6.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m6.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m7 = new Movie();
            m7.MovieNum = 3008;
            m7.Title = "It's a Wonderful Life";
            m7.Overview = "George Bailey has spent his entire life giving of himself to the people of Bedford Falls. He has always longed to travel but never had the opportunity in order to prevent rich skinflint Mr. Potter from taking over the entire town. All that prevents him from doing so is George's modest building and loan company, which was founded by his generous father. But on Christmas Eve, George's Uncle Billy loses the business's $8,000 while intending to deposit it in the bank. Potter finds the misplaced money, hides it from Billy, and George's troubles begin.";
            m7.ReleaseDate = new DateTime(1946, 12, 20);
            m7.Revenue = 9644124;
            m7.Runtime = 130;
            m7.Tagline = "It's a wonderful laugh! It's a wonderful love!";
            m7.MPAARating = enumMPAARating.PG;
            m7.Actors = "James Stewart, Donna Reed, Lionel Barrymore, Thomas Mitchell, Henry Travers, Beulah Bondi";
            db.Movies.AddOrUpdate(m => m.Title, m7);
            db.SaveChanges();


            m7 = db.Movies.FirstOrDefault(m => m.MovieNum == m7.MovieNum);
            m7.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m7.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m7.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m8 = new Movie();
            m8.MovieNum = 3009;
            m8.Title = "Annie Get Your Gun";
            m8.Overview = "This film adaptation of Irving Berlin's classic musical stars Betty Hutton as gunslinger Annie Oakley, who romances fellow sharpshooter Frank Butler (Howard Keel) as they travel with Buffalo Bill's Wild West Show. Previously off target when it comes to love, Annie proves you can get a man with a gun in this battle-of-the-sexes extravaganza, which features timeless numbers like \"Anything You Can Do\" and \"There's No Business Like Show Business.\"";
m8.ReleaseDate = new DateTime(1950, 5, 17);
            m8.Revenue = 8000000;
            m8.Runtime = 107;
            m8.Tagline = "Biggest musical under the sun!";
            m8.MPAARating = enumMPAARating.Unrated;
            m8.Actors = "Betty Hutton, Howard Keel, Louis Calhern, J. Carrol Naish, Edward Arnold, Keenan Wynn";
            db.Movies.AddOrUpdate(m => m.Title, m8);
            db.SaveChanges();


            m8 = db.Movies.FirstOrDefault(m => m.MovieNum == m8.MovieNum);
            m8.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m8.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m8.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m8.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Western"));
            db.SaveChanges();


            Movie m9 = new Movie();
            m9.MovieNum = 3010;
            m9.Title = "A Streetcar Named Desire";
            m9.Overview = "Disturbed Blanche DuBois moves in with her sister in New Orleans and is tormented by her brutish brother-in-law while her reality crumbles around her.";
            m9.ReleaseDate = new DateTime(1951, 9, 18);
            m9.Revenue = 8000000;
            m9.Runtime = 125;
            m9.Tagline = "...Blanche, who wanted so much to stay a lady...";
            m9.MPAARating = enumMPAARating.PG;
            m9.Actors = "Vivien Leigh, Marlon Brando, Kim Hunter, Karl Malden, Rudy Bond, Nick Dennis";
            db.Movies.AddOrUpdate(m => m.Title, m9);
            db.SaveChanges();


            m9 = db.Movies.FirstOrDefault(m => m.MovieNum == m9.MovieNum);
            m9.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m10 = new Movie();
            m10.MovieNum = 3011;
            m10.Title = "Singin' in the Rain";
            m10.Overview = "In 1927 Hollywood, Don Lockwood and Lina Lamont are a famous on-screen romantic pair in silent movies, but Lina mistakes the on-screen romance for real love. When their latest film is transformed into a musical, Don has the perfect voice for the songs, but strident voice faces the studio to dub her voice. Aspiring actress, Kathy Selden is brought in and, while she is working on the movie, Don falls in love with her.";
            m10.ReleaseDate = new DateTime(1952, 4, 10);
            m10.Revenue = 7200000;
            m10.Runtime = 103;
            m10.Tagline = "What a Glorious Feeling!";
            m10.MPAARating = enumMPAARating.G;
            m10.Actors = "Gene Kelly, Donald O'Connor, Debbie Reynolds, Jean Hagen, Millard Mitchell, Cyd Charisse";
            db.Movies.AddOrUpdate(m => m.Title, m10);
            db.SaveChanges();


            m10 = db.Movies.FirstOrDefault(m => m.MovieNum == m10.MovieNum);
            m10.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m10.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m10.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m11 = new Movie();
            m11.MovieNum = 3012;
            m11.Title = "Cat on a Hot Tin Roof";
            m11.Overview = "Brick, an alcoholic ex-football player, drinks his days away and resists the affections of his wife, Maggie. His reunion with his father, Big Daddy, who is dying of cancer, jogs a host of memories and revelations for both father and son.";
            m11.ReleaseDate = new DateTime(1958, 2, 17);
            m11.Revenue = 17570324;
            m11.Runtime = 108;
            m11.Tagline = "Just one pillow on her bed ... and just one desire in her heart!";
            m11.MPAARating = enumMPAARating.Unrated;
            m11.Actors = "Elizabeth Taylor, Paul Newman, Burl Ives, Judith Anderson, Jack Carson, Madeleine Sherwood";
            db.Movies.AddOrUpdate(m => m.Title, m11);
            db.SaveChanges();


            m11 = db.Movies.FirstOrDefault(m => m.MovieNum == m11.MovieNum);
            m11.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m11.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m12 = new Movie();
            m12.MovieNum = 3013;
            m12.Title = "Some Like It Hot";
            m12.Overview = "Two musicians witness a mob hit and struggle to find a way out of the city before they are found by the gangsters. Their only opportunity is to join an all-girl band as they leave on a tour. To make their getaway they must first disguise themselves as women, then keep their identities secret and deal with the problems this brings - such as an attractive bandmate and a very determined suitor.";
            m12.ReleaseDate = new DateTime(1959, 3, 18);
            m12.Revenue = 25000000;
            m12.Runtime = 122;
            m12.Tagline = "The movie too HOT for words!";
            m12.MPAARating = enumMPAARating.Unrated;
            m12.Actors = "Marilyn Monroe, Tony Curtis, Jack Lemmon, George Raft, Pat O\u2019Brien, Joe E. Brown";
            db.Movies.AddOrUpdate(m => m.Title, m12);
            db.SaveChanges();


            m12 = db.Movies.FirstOrDefault(m => m.MovieNum == m12.MovieNum);
            m12.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m12.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m13 = new Movie();
            m13.MovieNum = 3014;
            m13.Title = "Psycho";
            m13.Overview = "When larcenous real estate clerk Marion Crane goes on the lam with a wad of cash and hopes of starting a new life, she ends up at the notorious Bates Motel, where manager Norman Bates cares for his housebound mother. The place seems quirky, but fine??? until Marion decides to take a shower.";
            m13.ReleaseDate = new DateTime(1960, 6, 16);
            m13.Revenue = 32000000;
            m13.Runtime = 109;
            m13.Tagline = "The master of suspense moves his cameras into the icy blackness of the unexplored!";
            m13.MPAARating = enumMPAARating.R;
            m13.Actors = "Anthony Perkins, Vera Miles, John Gavin, Janet Leigh, Martin Balsam, John McIntire";
            db.Movies.AddOrUpdate(m => m.Title, m13);
            db.SaveChanges();


            m13 = db.Movies.FirstOrDefault(m => m.MovieNum == m13.MovieNum);
            m13.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m13.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m13.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m14 = new Movie();
            m14.MovieNum = 3015;
            m14.Title = "West Side Story";
            m14.Overview = "In the slums of the upper West Side of Manhattan, New York, a gang of Polish-American teenagers called the Jets compete with a rival gang of recently immigrated Puerto Ricans, the Sharks, to \"own\" the neighborhood streets. Tensions are high between the gangs but two kids, one from each rival gang, fall in love leading to tragedy.";
            m14.ReleaseDate = new DateTime(1961, 10, 18);
            m14.Revenue = 43656822;
            m14.Runtime = 152;
            m14.Tagline = "The screen achieves one of the great entertainments in the history of motion pictures";
            m14.MPAARating = enumMPAARating.Unrated;
            m14.Actors = "Natalie Wood, Richard Beymer, Russ Tamblyn, Rita Moreno, George Chakiris, Simon Oakland";
            db.Movies.AddOrUpdate(m => m.Title, m14);
            db.SaveChanges();


            m14 = db.Movies.FirstOrDefault(m => m.MovieNum == m14.MovieNum);
            m14.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m14.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m14.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            db.SaveChanges();


            Movie m15 = new Movie();
            m15.MovieNum = 3016;
            m15.Title = "The Man Who Shot Liberty Valance";
            m15.Overview = "A senator, who became famous for killing a notorious outlaw, returns for the funeral of an old friend and tells the truth about his deed.";
            m15.ReleaseDate = new DateTime(1962, 4, 22);
            m15.Revenue = 8000000;
            m15.Runtime = 123;
            m15.Tagline = "Together For The First Time - James Stewart - John Wayne - in the masterpiece of four-time Academy Award winner John Ford";
            m15.MPAARating = enumMPAARating.Unrated;
            m15.Actors = "John Wayne, James Stewart, Vera Miles, Lee Marvin, Edmond O'Brien, Ken Murray";
            db.Movies.AddOrUpdate(m => m.Title, m15);
            db.SaveChanges();


            m15 = db.Movies.FirstOrDefault(m => m.MovieNum == m15.MovieNum);
            m15.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Western"));
            db.SaveChanges();


            Movie m16 = new Movie();
            m16.MovieNum = 3017;
            m16.Title = "Dr. No";
            m16.Overview = "In the film that launched the James Bond saga, Agent 007 battles mysterious Dr. No, a scientific genius bent on destroying the U.S. space program. As the countdown to disaster begins, Bond must go to Jamaica, where he encounters beautiful Honey Ryder, to confront a megalomaniacal villain in his massive island headquarters.";
            m16.ReleaseDate = new DateTime(1962, 10, 4);
            m16.Revenue = 59600000;
            m16.Runtime = 110;
            m16.Tagline = "NOW meet the most extraordinary gentleman spy in all fiction!";
            m16.MPAARating = enumMPAARating.PG;
            m16.Actors = "Sean Connery, Ursula Andress, Joseph Wiseman, Jack Lord, Bernard Lee, Anthony Dawson";
            db.Movies.AddOrUpdate(m => m.Title, m16);
            db.SaveChanges();


            m16 = db.Movies.FirstOrDefault(m => m.MovieNum == m16.MovieNum);
            m16.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m16.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m16.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m17 = new Movie();
            m17.MovieNum = 3018;
            m17.Title = "Lawrence of Arabia";
            m17.Overview = "An epic about British officer T.E. Lawrence's mission to aid the Arab tribes in their revolt against the Ottoman Empire during the First World War. Lawrence becomes a flamboyant, messianic figure in the cause of Arab unity but his psychological instability threatens to undermine his achievements.";
            m17.ReleaseDate = new DateTime(1962, 12, 10);
            m17.Revenue = 69995385;
            m17.Runtime = 216;
            m17.Tagline = "A Mighty Motion Picture Of Action And Adventure!";
            m17.MPAARating = enumMPAARating.PG;
            m17.Actors = "Peter O'Toole, Alec Guinness, Anthony Quinn, Jack Hawkins, Omar Sharif, Claude Rains";
            db.Movies.AddOrUpdate(m => m.Title, m17);
            db.SaveChanges();


            m17 = db.Movies.FirstOrDefault(m => m.MovieNum == m17.MovieNum);
            m17.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m17.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m17.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "History"));
            m17.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            db.SaveChanges();


            Movie m18 = new Movie();
            m18.MovieNum = 3019;
            m18.Title = "To Kill a Mockingbird";
            m18.Overview = "In a small Alabama town in the 1930s, scrupulously honest and highly respected lawyer, Atticus Finch puts his career on the line when he agrees to represent Tom Robinson, a black man accused of rape. The trial and the events surrounding it are seen through the eyes of Finch's six-year-old daughter, Scout. While Robinson's trial gives the movie its momentum, there are plenty of anecdotal occurrences before and after the court date: Scout's ever-strengthening bond with older brother, Jem, her friendship with precocious young Dill Harris, her father's no-nonsense reactions to such life-and-death crises as a rampaging mad dog, and especially Scout's reactions to, and relationship with, Boo Radley, the reclusive 'village idiot' who turns out to be her salvation when she is attacked by a venomous bigot.";
            m18.ReleaseDate = new DateTime(1962, 12, 25);
            m18.Revenue = 13129846;
            m18.Runtime = 129;
            m18.Tagline = "The most beloved Pulitzer Prize book now comes vividly alive on the screen!?";
            m18.MPAARating = enumMPAARating.Unrated;
            m18.Actors = "Gregory Peck, Brock Peters, James Anderson, Mary Badham, Phillip Alford, John Megna";
            db.Movies.AddOrUpdate(m => m.Title, m18);
            db.SaveChanges();


            m18 = db.Movies.FirstOrDefault(m => m.MovieNum == m18.MovieNum);
            m18.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m18.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m19 = new Movie();
            m19.MovieNum = 3020;
            m19.Title = "A Hard Day's Night";
            m19.Overview = "Capturing John Lennon, Paul McCartney, George Harrison and Ringo Starr in their electrifying element, 'A Hard Day's Night' is a wildly irreverent journey through this pastiche of a day in the life of The Beatles during 1964. The band have to use all their guile and wit to avoid the pursuing fans and press to reach their scheduled television performance, in spite of Paul's troublemaking grandfather and Ringo's arrest.";
            m19.ReleaseDate = new DateTime(1964, 7, 6);
            m19.Revenue = 12299668;
            m19.Runtime = 88;
            m19.Tagline = "The Beatles, starring in their first full-length, hilarious, action-packed film!";
            m19.MPAARating = enumMPAARating.G;
            m19.Actors = "John Lennon, Paul McCartney, George Harrison, Ringo Starr, Wilfrid Brambell, Norman Rossington";
            db.Movies.AddOrUpdate(m => m.Title, m19);
            db.SaveChanges();


            m19 = db.Movies.FirstOrDefault(m => m.MovieNum == m19.MovieNum);
            m19.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m19.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            db.SaveChanges();


            Movie m20 = new Movie();
            m20.MovieNum = 3021;
            m20.Title = "Mary Poppins";
            m20.Overview = "The movie combines a diverting story, songs, color and sequences of live action blended with the movements of animated figures. Mary Poppins is a kind of Super-nanny who flies in with her umbrella in response to the request of the Banks children and proceeds to put things right with the aid of her rather extraordinary magical powers before flying off again.";
            m20.ReleaseDate = new DateTime(1964, 8, 27);
            m20.Revenue = 102272727;
            m20.Runtime = 139;
            m20.Tagline = "It's supercalifragilisticexpialidocious!";
            m20.MPAARating = enumMPAARating.G;
            m20.Actors = "Julie Andrews, Dick Van Dyke, David Tomlinson, Glynis Johns, Hermione Baddeley, Reta Shaw";
            db.Movies.AddOrUpdate(m => m.Title, m20);
            db.SaveChanges();


            m20 = db.Movies.FirstOrDefault(m => m.MovieNum == m20.MovieNum);
            m20.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m20.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m20.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m21 = new Movie();
            m21.MovieNum = 3022;
            m21.Title = "My Fair Lady";
            m21.Overview = "A misogynistic and snobbish phonetics professor agrees to a wager that he can take a flower girl and make her presentable in high society.";
            m21.ReleaseDate = new DateTime(1964, 10, 21);
            m21.Revenue = 72070731;
            m21.Runtime = 170;
            m21.Tagline = "The loverliest motion picture of them all!";
            m21.MPAARating = enumMPAARating.G;
            m21.Actors = "Audrey Hepburn, Rex Harrison, Stanley Holloway, Wilfrid Hyde-White, Gladys Cooper, Jeremy Brett";
            db.Movies.AddOrUpdate(m => m.Title, m21);
            db.SaveChanges();


            m21 = db.Movies.FirstOrDefault(m => m.MovieNum == m21.MovieNum);
            m21.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m21.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m21.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m21.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m22 = new Movie();
            m22.MovieNum = 3023;
            m22.Title = "The Sound of Music";
            m22.Overview = "Film adaptation of a classic Rodgers and Hammerstein musical based on a nun who becomes a governess for an Austrian family.";
            m22.ReleaseDate = new DateTime(1965, 3, 2);
            m22.Revenue = 286214286;
            m22.Runtime = 174;
            m22.Tagline = "The happiest sound in all the world!";
            m22.MPAARating = enumMPAARating.G;
            m22.Actors = "Julie Andrews, Christopher Plummer, Eleanor Parker, Richard Haydn, Peggy Wood, Charmian Carr";
            db.Movies.AddOrUpdate(m => m.Title, m22);
            db.SaveChanges();


            m22 = db.Movies.FirstOrDefault(m => m.MovieNum == m22.MovieNum);
            m22.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m22.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m22.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m22.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m23 = new Movie();
            m23.MovieNum = 3024;
            m23.Title = "Butch Cassidy and the Sundance Kid";
            m23.Overview = "In late 1890s Wyoming, Butch Cassidy is the affable, clever and talkative leader of the outlaw Hole in the Wall Gang. His closest companion is the laconic dead-shot 'Sundance Kid'. As the west rapidly becomes civilized, the law finally catches up to Butch, Sundance and their gang.  Chased doggedly by a special posse, the two decide to make their way to South America in hopes of evading their pursuers once and for all.";
            m23.ReleaseDate = new DateTime(1969, 9, 23);
            m23.Revenue = 102308889;
            m23.Runtime = 110;
            m23.Tagline = "Not that it matters, but most of it is true.";
            m23.MPAARating = enumMPAARating.PG;
            m23.Actors = "Paul Newman, Robert Redford, Katharine Ross, Strother Martin, Henry Jones, Jeff Corey";
            db.Movies.AddOrUpdate(m => m.Title, m23);
            db.SaveChanges();


            m23 = db.Movies.FirstOrDefault(m => m.MovieNum == m23.MovieNum);
            m23.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "History"));
            m23.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m23.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Western"));
            m23.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m24 = new Movie();
            m24.MovieNum = 3025;
            m24.Title = "Catch-22";
            m24.Overview = "A bombardier in World War II tries desperately to escape the insanity of the war. However, sometimes insanity is the only sane way to cope with a crazy situation. Catch-22 is a parody of a \"military mentality\" and of a bureaucratic society in general.";
            m24.ReleaseDate = new DateTime(1970, 6, 24);
            m24.Revenue = 24911670;
            m24.Runtime = 121;
            m24.Tagline = "The anti-war satire of epic proportions.";
            m24.MPAARating = enumMPAARating.R;
            m24.Actors = "Martin Balsam, Richard Benjamin, Art Garfunkel, Jack Gilford, Buck Henry, Bob Newhart";
            db.Movies.AddOrUpdate(m => m.Title, m24);
            db.SaveChanges();


            m24 = db.Movies.FirstOrDefault(m => m.MovieNum == m24.MovieNum);
            m24.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            m24.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m24.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m25 = new Movie();
            m25.MovieNum = 3026;
            m25.Title = "Willy Wonka & the Chocolate Factory";
            m25.Overview = "Eccentric candy man Willy Wonka prompts a worldwide frenzy when he announces that golden tickets hidden inside five of his delicious candy bars will admit their lucky holders into his top-secret confectionary. But does Wonka have an agenda hidden amid a world of Oompa Loompas and chocolate rivers?";
            m25.ReleaseDate = new DateTime(1971, 6, 29);
            m25.Revenue = 4000000;
            m25.Runtime = 100;
            m25.Tagline = "It's Scrumdiddlyumptious!";
            m25.MPAARating = enumMPAARating.G;
            m25.Actors = "Gene Wilder, Jack Albertson, Peter Ostrum, Roy Kinnear, Denise Nickerson, Leonard Stone";
            db.Movies.AddOrUpdate(m => m.Title, m25);
            db.SaveChanges();


            m25 = db.Movies.FirstOrDefault(m => m.MovieNum == m25.MovieNum);
            m25.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m25.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m26 = new Movie();
            m26.MovieNum = 3027;
            m26.Title = "Fiddler on the Roof";
            m26.Overview = "This lavishly produced and critically acclaimed screen adaptation of the international stage sensation tells the life-affirming story of Tevye (Topol), a poor milkman whose love, pride and faith help him face the oppression of turn-of-the-century Czarist Russia. Nominated for eight Academy Awards.";
            m26.ReleaseDate = new DateTime(1971, 11, 3);
            m26.Revenue = 83304330;
            m26.Runtime = 181;
            m26.Tagline = "To Life!";
            m26.MPAARating = enumMPAARating.G;
            m26.Actors = "Chaim Topol, Norma Crane, Leonard Frey, Molly Picon, Paul Mann, Rosalind Harris";
            db.Movies.AddOrUpdate(m => m.Title, m26);
            db.SaveChanges();


            m26 = db.Movies.FirstOrDefault(m => m.MovieNum == m26.MovieNum);
            m26.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m26.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m27 = new Movie();
            m27.MovieNum = 3028;
            m27.Title = "Diamonds Are Forever";
            m27.Overview = "Diamonds are stolen only to be sold again in the international market. James Bond infiltrates a smuggling mission to find out who???s guilty. The mission takes him to Las Vegas where Bond meets his archenemy Blofeld.";
            m27.ReleaseDate = new DateTime(1971, 12, 13);
            m27.Revenue = 116019547;
            m27.Runtime = 120;
            m27.Tagline = "The man who made 007 a household number";
            m27.MPAARating = enumMPAARating.PG;
            m27.Actors = "Sean Connery, Jill St. John, Charles Gray, Lana Wood, Jimmy Dean, Bruce Cabot";
            db.Movies.AddOrUpdate(m => m.Title, m27);
            db.SaveChanges();


            m27 = db.Movies.FirstOrDefault(m => m.MovieNum == m27.MovieNum);
            m27.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m27.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == " Action"));
            m27.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m28 = new Movie();
            m28.MovieNum = 3029;
            m28.Title = "American Graffiti";
            m28.Overview = "A couple of high school graduates spend one final night cruising the strip with their buddies before they go off to college.";
            m28.ReleaseDate = new DateTime(1973, 8, 1);
            m28.Revenue = 140000000;
            m28.Runtime = 110;
            m28.Tagline = "Where were you in '62?";
            m28.MPAARating = enumMPAARating.PG;
            m28.Actors = "Richard Dreyfuss, Ron Howard, Paul Le Mat, Charles Martin Smith, Cindy Williams, Candy Clark";
            db.Movies.AddOrUpdate(m => m.Title, m28);
            db.SaveChanges();


            m28 = db.Movies.FirstOrDefault(m => m.MovieNum == m28.MovieNum);
            m28.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m28.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m29 = new Movie();
            m29.MovieNum = 3030;
            m29.Title = "The Sting";
            m29.Overview = "Set in the 1930's this intricate caper deals with an ambitious small-time crook and a veteran con man who seek revenge on a vicious crime lord who murdered one of their gang.";
            m29.ReleaseDate = new DateTime(1973, 12, 25);
            m29.Revenue = 159616327;
            m29.Runtime = 129;
            m29.Tagline = "...all it takes is a little confidence.";
            m29.MPAARating = enumMPAARating.PG;
            m29.Actors = "Paul Newman, Robert Redford, Robert Shaw, Charles Durning, Ray Walston, Eileen Brennan";
            db.Movies.AddOrUpdate(m => m.Title, m29);
            db.SaveChanges();


            m29 = db.Movies.FirstOrDefault(m => m.MovieNum == m29.MovieNum);
            m29.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m29.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m29.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == " Drama"));
            db.SaveChanges();


            Movie m30 = new Movie();
            m30.MovieNum = 3031;
            m30.Title = "The Exorcist";
            m30.Overview = "12-year-old Regan MacNeil begins to adapt an explicit new personality as strange events befall the local area of Georgetown. Her mother becomes torn between science and superstition in a desperate bid to save her daughter, and ultimately turns to her last hope: Father Damien Karras, a troubled priest who is struggling with his own faith.";
            m30.ReleaseDate = new DateTime(1973, 12, 26);
            m30.Revenue = 441306145;
            m30.Runtime = 122;
            m30.Tagline = "Something almost beyond comprehension is happening to a girl on this street, in this house... and a man has been sent for as a last resort. This man is The Exorcist.";
            m30.MPAARating = enumMPAARating.R;
            m30.Actors = "Linda Blair, Max von Sydow, Ellen Burstyn, Jason Miller, Lee J. Cobb, Kitty Winn";
            db.Movies.AddOrUpdate(m => m.Title, m30);
            db.SaveChanges();


            m30 = db.Movies.FirstOrDefault(m => m.MovieNum == m30.MovieNum);
            m30.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m30.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m30.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m31 = new Movie();
            m31.MovieNum = 3032;
            m31.Title = "Blazing Saddles";
            m31.Overview = "A town ???? where everyone seems to be named Johnson ???? is in the way of the railroad and, in order to grab their land, Hedley Lemar, a politically connected nasty person, sends in his henchmen to make the town unlivable. After the sheriff is killed, the town demands a new sheriff from the Governor, so Hedley convinces him to send the town the first black sheriff in the west.";
            m31.ReleaseDate = new DateTime(1974, 2, 7);
            m31.Revenue = 119500000;
            m31.Runtime = 93;
            m31.Tagline = "Never give a saga an even break!";
            m31.MPAARating = enumMPAARating.R;
            m31.Actors = "Cleavon Little, Gene Wilder, Harvey Korman, Slim Pickens, Madeline Kahn, Mel Brooks";
            db.Movies.AddOrUpdate(m => m.Title, m31);
            db.SaveChanges();


            m31 = db.Movies.FirstOrDefault(m => m.MovieNum == m31.MovieNum);
            m31.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Western"));
            m31.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m32 = new Movie();
            m32.MovieNum = 3033;
            m32.Title = "Monty Python and the Holy Grail";
            m32.Overview = "King Arthur, accompanied by his squire, recruits his Knights of the Round Table, including Sir Bedevere the Wise, Sir Lancelot the Brave, Sir Robin the Not-Quite-So-Brave-As-Sir-Lancelot and Sir Galahad the Pure. On the way, Arthur battles the Black Knight who, despite having had all his limbs chopped off, insists he can still fight. They reach Camelot, but Arthur decides not  to enter, as \"it is a silly place\".";
            m32.ReleaseDate = new DateTime(1975, 3, 13);
            m32.Revenue = 5028948;
            m32.Runtime = 91;
            m32.Tagline = "And now! At Last! Another film completely different from some of the other films which aren't quite the same as this one is.";
            m32.MPAARating = enumMPAARating.PG;
            m32.Actors = "Graham Chapman, John Cleese, Terry Gilliam, Eric Idle, Terry Jones, Michael Palin";
            db.Movies.AddOrUpdate(m => m.Title, m32);
            db.SaveChanges();


            m32 = db.Movies.FirstOrDefault(m => m.MovieNum == m32.MovieNum);
            m32.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m32.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m32.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m33 = new Movie();
            m33.MovieNum = 3034;
            m33.Title = "Jaws";
            m33.Overview = "An insatiable great white shark terrorizes the townspeople of Amity Island, The police chief, an oceanographer and a grizzled shark hunter seek to destroy the bloodthirsty beast.";
            m33.ReleaseDate = new DateTime(1975, 6, 18);
            m33.Revenue = 470654000;
            m33.Runtime = 124;
            m33.Tagline = "Don't go in the water.";
            m33.MPAARating = enumMPAARating.PG;
            m33.Actors = "Roy Scheider, Robert Shaw, Richard Dreyfuss, Lorraine Gary, Murray Hamilton, Carl Gottlieb";
            db.Movies.AddOrUpdate(m => m.Title, m33);
            db.SaveChanges();


            m33 = db.Movies.FirstOrDefault(m => m.MovieNum == m33.MovieNum);
            m33.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m33.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m33.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m34 = new Movie();
            m34.MovieNum = 3035;
            m34.Title = "Star Wars";
            m34.Overview = "Princess Leia is captured and held hostage by the evil Imperial forces in their effort to take over the galactic Empire. Venturesome Luke Skywalker and dashing captain Han Solo team together with the loveable robot duo R2-D2 and C-3PO to rescue the beautiful princess and restore peace and justice in the Empire.";
            m34.ReleaseDate = new DateTime(1977, 5, 25);
            m34.Revenue = 775398007;
            m34.Runtime = 121;
            m34.Tagline = "A long time ago in a galaxy far, far away...";
            m34.MPAARating = enumMPAARating.PG;
            m34.Actors = "Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing, Alec Guinness, Anthony Daniels";
            db.Movies.AddOrUpdate(m => m.Title, m34);
            db.SaveChanges();


            m34 = db.Movies.FirstOrDefault(m => m.MovieNum == m34.MovieNum);
            m34.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m34.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m34.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            db.SaveChanges();


            Movie m35 = new Movie();
            m35.MovieNum = 3036;
            m35.Title = "The Spy Who Loved Me";
            m35.Overview = "Russian and British submarines with nuclear missiles on board both vanish from sight without a trace. England and Russia both blame each other as James Bond tries to solve the riddle of the disappearing ships. But the KGB also has an agent on the case.";
            m35.ReleaseDate = new DateTime(1977, 7, 7);
            m35.Revenue = 185438673;
            m35.Runtime = 125;
            m35.Tagline = "It's the BIGGEST. It's the BEST. It's BOND. And B-E-Y-O-N-D.";
            m35.MPAARating = enumMPAARating.PG;
            m35.Actors = "Roger Moore, Barbara Bach, Curd Joergens, Richard Kiel, Caroline Munro, Walter Gotell";
            db.Movies.AddOrUpdate(m => m.Title, m35);
            db.SaveChanges();


            m35 = db.Movies.FirstOrDefault(m => m.MovieNum == m35.MovieNum);
            m35.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m35.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m35.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m36 = new Movie();
            m36.MovieNum = 3037;
            m36.Title = "Close Encounters of the Third Kind";
            m36.Overview = "After an encounter with UFOs, a line worker feels undeniably drawn to an isolated area in the wilderness where something spectacular is about to happen.";
            m36.ReleaseDate = new DateTime(1977, 11, 16);
            m36.Revenue = 303788635;
            m36.Runtime = 135;
            m36.Tagline = "We are not alone.";
            m36.MPAARating = enumMPAARating.PG;
            m36.Actors = "Richard Dreyfuss, Francois Truffaut, Teri Garr, Melinda Dillon, Bob Balaban, J. Patrick McNamara";
            db.Movies.AddOrUpdate(m => m.Title, m36);
            db.SaveChanges();


            m36 = db.Movies.FirstOrDefault(m => m.MovieNum == m36.MovieNum);
            m36.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m36.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m37 = new Movie();
            m37.MovieNum = 3038;
            m37.Title = "Grease";
            m37.Overview = "Australian good girl Sandy and greaser Danny fell in love over the summer. But when they unexpectedly discover they're now in the same high school, will they be able to rekindle their romance despite their eccentric friends?";
            m37.ReleaseDate = new DateTime(1978, 7, 7);
            m37.Revenue = 181813770;
            m37.Runtime = 110;
            m37.Tagline = "Grease is the word";
            m37.MPAARating = enumMPAARating.PG13;
            m37.Actors = "John Travolta, Olivia Newton-John, Stockard Channing, Jeff Conaway, Didi Conn, Barry Pearl";
            db.Movies.AddOrUpdate(m => m.Title, m37);
            db.SaveChanges();


            m37 = db.Movies.FirstOrDefault(m => m.MovieNum == m37.MovieNum);
            m37.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m38 = new Movie();
            m38.MovieNum = 3039;
            m38.Title = "Animal House";
            m38.Overview = "At a 1962 College, Dean Vernon Wormer is determined to expel the entire Delta Tau Chi Fraternity, but those troublemakers have other plans for him.";
            m38.ReleaseDate = new DateTime(1978, 7, 27);
            m38.Revenue = 141000000;
            m38.Runtime = 109;
            m38.Tagline = "It was the Deltas against the rules... the rules lost!";
            m38.MPAARating = enumMPAARating.R;
            m38.Actors = "John Belushi, Tim Matheson, John Vernon, Verna Bloom, Tom Hulce, Cesare Danova";
            db.Movies.AddOrUpdate(m => m.Title, m38);
            db.SaveChanges();


            m38 = db.Movies.FirstOrDefault(m => m.MovieNum == m38.MovieNum);
            m38.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m39 = new Movie();
            m39.MovieNum = 3040;
            m39.Title = "Halloween";
            m39.Overview = "In John Carpenter's horror classic, a psychotic murderer, institutionalized since childhood for the murder of his sister, escapes and stalks a bookish teenage girl and her friends while his doctor chases him through the streets.";
            m39.ReleaseDate = new DateTime(1978, 10, 25);
            m39.Revenue = 70000000;
            m39.Runtime = 91;
            m39.Tagline = "The Night He Came Home";
            m39.MPAARating = enumMPAARating.R;
            m39.Actors = "Donald Pleasence, Jamie Lee Curtis, P.J. Soles, Nancy Kyes, Nick Castle, Tony Moran";
            db.Movies.AddOrUpdate(m => m.Title, m39);
            db.SaveChanges();


            m39 = db.Movies.FirstOrDefault(m => m.MovieNum == m39.MovieNum);
            m39.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m39.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m40 = new Movie();
            m40.MovieNum = 3041;
            m40.Title = "Alien";
            m40.Overview = "During its return to the earth, commercial spaceship Nostromo intercepts a distress signal from a distant planet. When a three-member team of the crew discovers a chamber containing thousands of eggs on the planet, a creature inside one of the eggs attacks an explorer. The entire crew is unaware of the impending nightmare set to descend upon them when the alien parasite planted inside its unfortunate host is birthed.";
            m40.ReleaseDate = new DateTime(1979, 5, 25);
            m40.Revenue = 104931801;
            m40.Runtime = 117;
            m40.Tagline = "In space no one can hear you scream.";
            m40.MPAARating = enumMPAARating.R;
            m40.Actors = "Tom Skerritt, Sigourney Weaver, Veronica Cartwright, Harry Dean Stanton, John Hurt, Ian Holm";
            db.Movies.AddOrUpdate(m => m.Title, m40);
            db.SaveChanges();


            m40 = db.Movies.FirstOrDefault(m => m.MovieNum == m40.MovieNum);
            m40.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m40.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m40.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            m40.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m41 = new Movie();
            m41.MovieNum = 3042;
            m41.Title = "The Muppet Movie";
            m41.Overview = "Kermit the Frog is persuaded by agent Dom DeLuise to pursue a career in Hollywood. Along the way, Kermit picks up Fozzie Bear, Miss Piggy, Gonzo, and a motley crew of other Muppets with similar aspirations. Meanwhile, Kermit must elude the grasp of a frog-leg restaurant magnate.";
            m41.ReleaseDate = new DateTime(1979, 5, 31);
            m41.Revenue = 76657000;
            m41.Runtime = 97;
            m41.Tagline = "More entertaining than humanly possible.";
            m41.MPAARating = enumMPAARating.G;
            m41.Actors = "Jim Henson, Frank Oz, Jerry Nelson, Richard Hunt, Dave Goelz, Charles Durning";
            db.Movies.AddOrUpdate(m => m.Title, m41);
            db.SaveChanges();


            m41 = db.Movies.FirstOrDefault(m => m.MovieNum == m41.MovieNum);
            m41.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m41.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m41.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m42 = new Movie();
            m42.MovieNum = 3043;
            m42.Title = "Apocalypse Now";
            m42.Overview = "At the height of the Vietnam war, Captain Benjamin Willard is sent on a dangerous mission that, officially, \"does not exist, nor will it ever exist.\" His goal is to locate - and eliminate - a mysterious Green Beret Colonel named Walter Kurtz, who has been leading his personal army on illegal guerrilla missions into enemy territory.";
            m42.ReleaseDate = new DateTime(1979, 8, 15);
            m42.Revenue = 89460381;
            m42.Runtime = 153;
            m42.Tagline = "This is the end...";
            m42.MPAARating = enumMPAARating.R;
            m42.Actors = "Martin Sheen, Marlon Brando, Robert Duvall, Frederic Forrest, Sam Bottoms, Laurence Fishburne";
            db.Movies.AddOrUpdate(m => m.Title, m42);
            db.SaveChanges();


            m42 = db.Movies.FirstOrDefault(m => m.MovieNum == m42.MovieNum);
            m42.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m42.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            db.SaveChanges();


            Movie m43 = new Movie();
            m43.MovieNum = 3044;
            m43.Title = "The Empire Strikes Back";
            m43.Overview = "The epic saga continues as Luke Skywalker, in hopes of defeating the evil Galactic Empire, learns the ways of the Jedi from aging master Yoda. But Darth Vader is more determined than ever to capture Luke. Meanwhile, rebel leader Princess Leia, cocky Han Solo, Chewbacca, and droids C-3PO and R2-D2 are thrown into various stages of capture, betrayal and despair.";
            m43.ReleaseDate = new DateTime(1980, 5, 17);
            m43.Revenue = 538400000;
            m43.Runtime = 124;
            m43.Tagline = "The Adventure Continues...";
            m43.MPAARating = enumMPAARating.PG;
            m43.Actors = "Mark Hamill, Harrison Ford, Carrie Fisher, Billy Dee Williams, Anthony Daniels, David Prowse";
            db.Movies.AddOrUpdate(m => m.Title, m43);
            db.SaveChanges();


            m43 = db.Movies.FirstOrDefault(m => m.MovieNum == m43.MovieNum);
            m43.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m43.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m43.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m44 = new Movie();
            m44.MovieNum = 3045;
            m44.Title = "The Shining";
            m44.Overview = "Jack Torrance accepts a caretaker job at the Overlook Hotel, where he, along with his wife Wendy and their son Danny, must live isolated from the rest of the world for the winter. But they aren't prepared for the madness that lurks within.";
            m44.ReleaseDate = new DateTime(1980, 5, 22);
            m44.Revenue = 44017374;
            m44.Runtime = 144;
            m44.Tagline = "A masterpiece of modern horror.";
            m44.MPAARating = enumMPAARating.R;
            m44.Actors = "Jack Nicholson, Shelley Duvall, Danny Lloyd, Scatman Crothers, Barry Nelson, Philip Stone";
            db.Movies.AddOrUpdate(m => m.Title, m44);
            db.SaveChanges();


            m44 = db.Movies.FirstOrDefault(m => m.MovieNum == m44.MovieNum);
            m44.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m44.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m45 = new Movie();
            m45.MovieNum = 3046;
            m45.Title = "Airplane!";
            m45.Overview = "Alcoholic pilot, Ted Striker has developed a fear of flying due to wartime trauma, but nevertheless boards a passenger jet in an attempt to woo back his stewardess girlfriend. Food poisoning decimates the passengers and crew, leaving it up to Striker to land the plane with the help of a glue-sniffing air traffic controller and Striker's vengeful former Air Force captain, who must both talk him down.";
            m45.ReleaseDate = new DateTime(1980, 7, 2);
            m45.Revenue = 83453539;
            m45.Runtime = 88;
            m45.Tagline = "What's slower than a speeding bullet, and able to hit tall buildings at a single bound?";
            m45.MPAARating = enumMPAARating.PG;
            m45.Actors = "Robert Hays, Julie Hagerty, Kareem Abdul-Jabbar, Lloyd Bridges, Peter Graves, Leslie Nielsen";
            db.Movies.AddOrUpdate(m => m.Title, m45);
            db.SaveChanges();


            m45 = db.Movies.FirstOrDefault(m => m.MovieNum == m45.MovieNum);
            m45.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m46 = new Movie();
            m46.MovieNum = 3047;
            m46.Title = "Caddyshack";
            m46.Overview = "At an exclusive country club, an ambitious young caddy, Danny Noonan, eagerly pursues a caddy scholarship in hopes of attending college and, in turn, avoiding a job at the lumber yard. In order to succeed, he must first win the favour of the elitist Judge Smails, and then the caddy golf tournament which Smails sponsors.";
            m46.ReleaseDate = new DateTime(1980, 7, 25);
            m46.Revenue = 39846344;
            m46.Runtime = 98;
            m46.Tagline = "The snobs against the slobs!";
            m46.MPAARating = enumMPAARating.R;
            m46.Actors = "Chevy Chase, Rodney Dangerfield, Ted Knight, Michael O'Keefe, Bill Murray, Sarah Holcomb";
            db.Movies.AddOrUpdate(m => m.Title, m46);
            db.SaveChanges();


            m46 = db.Movies.FirstOrDefault(m => m.MovieNum == m46.MovieNum);
            m46.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m47 = new Movie();
            m47.MovieNum = 3048;
            m47.Title = "Raging Bull";
            m47.Overview = "When Jake LaMotta steps into a boxing ring and obliterates his opponent, he's a prizefighter. But when he treats his family and friends the same way, he's a ticking time bomb, ready to go off at any moment. Though LaMotta wants his family's love, something always seems to come between them. Perhaps it's his violent bouts of paranoia and jealousy. This kind of rage helped make him a champ, but in real life, he winds up in the ring alone.";
            m47.ReleaseDate = new DateTime(1980, 11, 14);
            m47.Revenue = 23000000;
            m47.Runtime = 129;
            m47.Tagline = "not avaliable";
            m47.MPAARating = enumMPAARating.R;
            m47.Actors = "Robert De Niro, Joe Pesci, Cathy Moriarty, Frank Vincent, Nicholas Colasanto, Theresa Saldana";
            db.Movies.AddOrUpdate(m => m.Title, m47);
            db.SaveChanges();


            m47 = db.Movies.FirstOrDefault(m => m.MovieNum == m47.MovieNum);
            m47.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m48 = new Movie();
            m48.MovieNum = 3049;
            m48.Title = "Raiders of the Lost Ark";
            m48.Overview = "When Dr. Indiana Jones ???? the tweed-suited professor who just happens to be a celebrated archaeologist ???? is hired by the government to locate the legendary Ark of the Covenant, he finds himself up against the entire Nazi regime.";
            m48.ReleaseDate = new DateTime(1981, 6, 12);
            m48.Revenue = 389925971;
            m48.Runtime = 115;
            m48.Tagline = "Indiana Jones - the new hero from the creators of JAWS and STAR WARS.";
            m48.MPAARating = enumMPAARating.PG;
            m48.Actors = "Harrison Ford, Karen Allen, Paul Freeman, Ronald Lacey, John Rhys-Davies, Denholm Elliott";
            db.Movies.AddOrUpdate(m => m.Title, m48);
            db.SaveChanges();


            m48 = db.Movies.FirstOrDefault(m => m.MovieNum == m48.MovieNum);
            m48.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m48.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            db.SaveChanges();


            Movie m49 = new Movie();
            m49.MovieNum = 3050;
            m49.Title = "E.T. the Extra-Terrestrial";
            m49.Overview = "After a gentle alien becomes stranded on Earth, the being is discovered and befriended by a young boy named Elliott. Bringing the extraterrestrial into his suburban California house, Elliott introduces E.T., as the alien is dubbed, to his brother and his little sister, Gertie, and the children decide to keep its existence a secret. Soon, however, E.T. falls ill, resulting in government intervention and a dire situation for both Elliott and the alien.";
            m49.ReleaseDate = new DateTime(1982, 4, 3);
            m49.Revenue = 792910554;
            m49.Runtime = 115;
            m49.Tagline = "He is afraid. He is alone. He is three million light years from home.";
            m49.MPAARating = enumMPAARating.PG;
            m49.Actors = "Henry Thomas, Drew Barrymore, Robert MacNaughton, Dee Wallace, Peter Coyote, Erika Eleniak";
            db.Movies.AddOrUpdate(m => m.Title, m49);
            db.SaveChanges();


            m49 = db.Movies.FirstOrDefault(m => m.MovieNum == m49.MovieNum);
            m49.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m49.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m49.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m49.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m50 = new Movie();
            m50.MovieNum = 3051;
            m50.Title = "Fast Times at Ridgemont High";
            m50.Overview = "Follows a group of high school students growing up in southern California, based on the real-life adventures chronicled by Cameron Crowe. Stacy Hamilton and Mark Ratner are looking for a love interest, and are helped along by their older classmates, Linda Barrett and Mike Damone, respectively. The center of the film is held by Jeff Spicoli, a perpetually stoned surfer dude who faces off with the resolute Mr. Hand, who is convinced that everyone is on dope.";
            m50.ReleaseDate = new DateTime(1982, 8, 13);
            m50.Revenue = 27092880;
            m50.Runtime = 90;
            m50.Tagline = "Fast Cars, Fast Girls, Fast Carrots...Fast Carrots?";
            m50.MPAARating = enumMPAARating.R;
            m50.Actors = "Sean Penn, Jennifer Jason Leigh, Judge Reinhold, Phoebe Cates, Brian Backer, Robert Romanus";
            db.Movies.AddOrUpdate(m => m.Title, m50);
            db.SaveChanges();


            m50 = db.Movies.FirstOrDefault(m => m.MovieNum == m50.MovieNum);
            m50.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m51 = new Movie();
            m51.MovieNum = 3052;
            m51.Title = "Return of the Jedi";
            m51.Overview = "As Rebel leaders map their strategy for an all-out attack on the Emperor's newer, bigger Death Star. Han Solo remains frozen in the cavernous desert fortress of Jabba the Hutt, the most loathsome outlaw in the universe, who is also keeping Princess Leia as a slave girl. Now a master of the Force, Luke Skywalker rescues his friends, but he cannot become a true Jedi Knight until he wages his own crucial battle against Darth Vader, who has sworn to win Luke over to the dark side of the Force.";
            m51.ReleaseDate = new DateTime(1983, 5, 23);
            m51.Revenue = 572700000;
            m51.Runtime = 135;
            m51.Tagline = "The Empire Falls...";
            m51.MPAARating = enumMPAARating.PG;
            m51.Actors = "Mark Hamill, Harrison Ford, Carrie Fisher, Billy Dee Williams, Anthony Daniels, David Prowse";
            db.Movies.AddOrUpdate(m => m.Title, m51);
            db.SaveChanges();


            m51 = db.Movies.FirstOrDefault(m => m.MovieNum == m51.MovieNum);
            m51.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m51.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m51.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m52 = new Movie();
            m52.MovieNum = 3053;
            m52.Title = "WarGames";
            m52.Overview = "High School student David Lightman (Matthew Broderick) has a talent for hacking. But while trying to hack into a computer system to play unreleased video games, he unwittingly taps into the Defense Department's war computer and initiates a confrontation of global proportions! Together with his girlfriend (Ally Sheedy) and a wizardly computer genius (John Wood), David must race against time to outwit his opponent...and prevent a nuclear Armageddon.";
            m52.ReleaseDate = new DateTime(1983, 6, 3);
            m52.Revenue = 79567667;
            m52.Runtime = 114;
            m52.Tagline = "Is it a game, or is it real?";
            m52.MPAARating = enumMPAARating.PG;
            m52.Actors = "Matthew Broderick, Dabney Coleman, Ally Sheedy, John Wood, Barry Corbin, Juanin Clay";
            db.Movies.AddOrUpdate(m => m.Title, m52);
            db.SaveChanges();


            m52 = db.Movies.FirstOrDefault(m => m.MovieNum == m52.MovieNum);
            m52.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            m52.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m53 = new Movie();
            m53.MovieNum = 3054;
            m53.Title = "Trading Places";
            m53.Overview = "A snobbish investor and a wily street con-artist find their positions reversed as part of a bet by two callous millionaires.";
            m53.ReleaseDate = new DateTime(1983, 6, 7);
            m53.Revenue = 90400000;
            m53.Runtime = 116;
            m53.Tagline = "Some very funny business.";
            m53.MPAARating = enumMPAARating.R;
            m53.Actors = "Eddie Murphy, Dan Aykroyd, Jamie Lee Curtis, Jim Belushi, Denholm Elliott, Ralph Bellamy";
            db.Movies.AddOrUpdate(m => m.Title, m53);
            db.SaveChanges();


            m53 = db.Movies.FirstOrDefault(m => m.MovieNum == m53.MovieNum);
            m53.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m54 = new Movie();
            m54.MovieNum = 3055;
            m54.Title = "A Christmas Story";
            m54.Overview = "The comic mishaps and adventures of a young boy named Ralph, trying to convince his parents, teachers, and Santa that a Red Ryder B.B. gun really is the perfect Christmas gift for the 1940s.";
            m54.ReleaseDate = new DateTime(1983, 11, 18);
            m54.Revenue = 19294144;
            m54.Runtime = 94;
            m54.Tagline = "Peace, Harmony, Comfort and Joy... Maybe Next Year.";
            m54.MPAARating = enumMPAARating.PG;
            m54.Actors = "Melinda Dillon, Darren McGavin, Peter Billingsley, Jean Shepherd, Ian Petrella, Scott Schwartz";
            db.Movies.AddOrUpdate(m => m.Title, m54);
            db.SaveChanges();


            m54 = db.Movies.FirstOrDefault(m => m.MovieNum == m54.MovieNum);
            m54.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m54.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m55 = new Movie();
            m55.MovieNum = 3056;
            m55.Title = "Footloose";
            m55.Overview = "When teenager Ren and his family move from big-city Chicago to a small town in the West, he's in for a real case of culture shock.";
            m55.ReleaseDate = new DateTime(1984, 2, 17);
            m55.Revenue = 80035402;
            m55.Runtime = 107;
            m55.Tagline = "He's a big-city kid in a small town. They said he'd never win. He knew he had to.";
            m55.MPAARating = enumMPAARating.PG;
            m55.Actors = "Kevin Bacon, John Lithgow, Dianne Wiest, Chris Penn, Lori Singer, Sarah Jessica Parker";
            db.Movies.AddOrUpdate(m => m.Title, m55);
            db.SaveChanges();


            m55 = db.Movies.FirstOrDefault(m => m.MovieNum == m55.MovieNum);
            m55.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m55.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m55.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m55.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m56 = new Movie();
            m56.MovieNum = 3057;
            m56.Title = "Back to the Future";
            m56.Overview = "Eighties teenager Marty McFly is accidentally sent back in time to 1955, inadvertently disrupting his parents' first meeting and attracting his mother's romantic interest. Marty must repair the damage to history by rekindling his parents' romance and - with the help of his eccentric inventor friend Doc Brown - return to 1985.";
            m56.ReleaseDate = new DateTime(1985, 7, 3);
            m56.Revenue = 381109762;
            m56.Runtime = 116;
            m56.Tagline = "He's the only kid ever to get into trouble before he was born.";
            m56.MPAARating = enumMPAARating.PG;
            m56.Actors = "Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, Thomas F. Wilson, Claudia Wells";
            db.Movies.AddOrUpdate(m => m.Title, m56);
            db.SaveChanges();


            m56 = db.Movies.FirstOrDefault(m => m.MovieNum == m56.MovieNum);
            m56.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m56.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m56.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m56.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m57 = new Movie();
            m57.MovieNum = 3058;
            m57.Title = "The Color Purple";
            m57.Overview = "An epic tale spanning forty years in the life of Celie (Whoopi Goldberg), an African-American woman living in the South who survives incredible abuse and bigotry.  After Celie's abusive father marries her off to the equally debasing \"Mister\" Albert Johnson (Danny Glover), things go from bad to worse, leaving Celie to find companionship anywhere she can.  She perseveres, holding on to her dream of one day being reunited with her sister in Africa.  Based on the novel by Alice Walker.";
            m57.ReleaseDate = new DateTime(1985, 12, 18);
            m57.Revenue = 146292009;
            m57.Runtime = 154;
            m57.Tagline = "It's about life. It's about love. It's about us.";
            m57.MPAARating = enumMPAARating.PG13;
            m57.Actors = "Whoopi Goldberg, Margaret Avery, Danny Glover, Akosua Busia, Oprah Winfrey, Willard E. Pugh";
            db.Movies.AddOrUpdate(m => m.Title, m57);
            db.SaveChanges();


            m57 = db.Movies.FirstOrDefault(m => m.MovieNum == m57.MovieNum);
            m57.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m58 = new Movie();
            m58.MovieNum = 3059;
            m58.Title = "Top Gun";
            m58.Overview = "For Lieutenant Pete 'Maverick' Mitchell and his friend and Co-Pilot Nick 'Goose' Bradshaw being accepted into an elite training school for fighter pilots is a dream come true.  A tragedy, as well as personal demons, threaten Pete's dreams of becoming an Ace pilot.";
            m58.ReleaseDate = new DateTime(1986, 5, 16);
            m58.Revenue = 356830601;
            m58.Runtime = 110;
            m58.Tagline = "Up there with the best of the best.";
            m58.MPAARating = enumMPAARating.PG;
            m58.Actors = "Tom Cruise, Kelly McGillis, Val Kilmer, Anthony Edwards, Tom Skerritt, Michael Ironside";
            db.Movies.AddOrUpdate(m => m.Title, m58);
            db.SaveChanges();


            m58 = db.Movies.FirstOrDefault(m => m.MovieNum == m58.MovieNum);
            m58.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m58.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m58.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            db.SaveChanges();


            Movie m59 = new Movie();
            m59.MovieNum = 3060;
            m59.Title = "Little Shop of Horrors";
            m59.Overview = "Seymour Krelborn is a nerdy orphan working at Mushnik's, a flower shop in urban Skid Row. He harbors a crush on fellow co-worker Audrey Fulquard, and is berated by Mr. Mushnik daily. One day as Seymour is seeking a new mysterious plant, he finds a very mysterious unidentified plant which he calls Audrey II. The plant seems to have a craving for blood and soon begins to sing for his supper.";
            m59.ReleaseDate = new DateTime(1986, 12, 19);
            m59.Revenue = 38748395;
            m59.Runtime = 94;
            m59.Tagline = "Don't feed the plants.";
            m59.MPAARating = enumMPAARating.PG13;
            m59.Actors = "Rick Moranis, Ellen Greene, Vincent Gardenia, Steve Martin, Tisha Campbell-Martin, John Candy";
            db.Movies.AddOrUpdate(m => m.Title, m59);
            db.SaveChanges();


            m59 = db.Movies.FirstOrDefault(m => m.MovieNum == m59.MovieNum);
            m59.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Horror"));
            m59.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m59.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m60 = new Movie();
            m60.MovieNum = 3061;
            m60.Title = "Spaceballs";
            m60.Overview = "When the nefarious Dark Helmet hatches a plan to snatch Princess Vespa and steal her planet's air, space-bum-for-hire Lone Starr and his clueless sidekick fly to the rescue. Along the way, they meet Yogurt, who puts Lone Starr wise to the power of \"The Schwartz.\" Can he master it in time to save the day?";
            m60.ReleaseDate = new DateTime(1987, 6, 24);
            m60.Revenue = 38119483;
            m60.Runtime = 96;
            m60.Tagline = "May the schwartz be with you";
            m60.MPAARating = enumMPAARating.PG;
            m60.Actors = "Mel Brooks, Rick Moranis, Bill Pullman, Daphne Zuniga, John Candy, George Wyner";
            db.Movies.AddOrUpdate(m => m.Title, m60);
            db.SaveChanges();


            m60 = db.Movies.FirstOrDefault(m => m.MovieNum == m60.MovieNum);
            m60.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m60.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m61 = new Movie();
            m61.MovieNum = 3062;
            m61.Title = "The Princess Bride";
            m61.Overview = "In this enchantingly cracked fairy tale, the beautiful Princess Buttercup and the dashing Westley must overcome staggering odds to find happiness amid six-fingered swordsmen, murderous princes, Sicilians and rodents of unusual size. But even death can't stop these true lovebirds from triumphing.";
            m61.ReleaseDate = new DateTime(1987, 9, 18);
            m61.Revenue = 30857814;
            m61.Runtime = 98;
            m61.Tagline = "It's as real as the feelings you feel.";
            m61.MPAARating = enumMPAARating.PG;
            m61.Actors = "Cary Elwes, Robin Wright, Mandy Patinkin, Andre the Giant, Chris Sarandon, Christopher Guest";
            db.Movies.AddOrUpdate(m => m.Title, m61);
            db.SaveChanges();


            m61 = db.Movies.FirstOrDefault(m => m.MovieNum == m61.MovieNum);
            m61.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m61.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m61.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m61.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m61.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m62 = new Movie();
            m62.MovieNum = 3063;
            m62.Title = "Big";
            m62.Overview = "A young boy, Josh Baskin makes a wish at a carnival machine to be big. He wakes up the following morning to find that it has been granted and his body has grown older overnight. But he is still the same 13-year-old boy inside. Now he must learn how to cope with the unfamiliar world of grown-ups including getting a job and having his first romantic encounter with a woman. What will he find out about this strange world?";
            m62.ReleaseDate = new DateTime(1988, 6, 3);
            m62.Revenue = 151668774;
            m62.Runtime = 104;
            m62.Tagline = "You're Only Young Once But For Josh It Might Just Last A Lifetime.";
            m62.MPAARating = enumMPAARating.PG;
            m62.Actors = "Tom Hanks, Elizabeth Perkins, Robert Loggia, John Heard, Jared Rushton, David Moscow";
            db.Movies.AddOrUpdate(m => m.Title, m62);
            db.SaveChanges();


            m62 = db.Movies.FirstOrDefault(m => m.MovieNum == m62.MovieNum);
            m62.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m62.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m62.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m62.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m62.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m63 = new Movie();
            m63.MovieNum = 3064;
            m63.Title = "The Land Before Time";
            m63.Overview = "An orphaned brontosaurus named Littlefoot sets off in search of the legendary Great Valley. A land of lush vegetation where the dinosaurs can thrive and live in peace. Along the way he meets four other young dinosaurs, each one a different species, and they encounter several obstacles as they learn to work together in order to survive.";
            m63.ReleaseDate = new DateTime(1988, 11, 18);
            m63.Revenue = 84460846;
            m63.Runtime = 69;
            m63.Tagline = "A new adventure is born.";
            m63.MPAARating = enumMPAARating.G;
            m63.Actors = "Gabriel Damon, Candace Hutson, Judith Barsi, Will Ryan, Pat Hingle, Helen Shaver";
            db.Movies.AddOrUpdate(m => m.Title, m63);
            db.SaveChanges();


            m63 = db.Movies.FirstOrDefault(m => m.MovieNum == m63.MovieNum);
            m63.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m63.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m63.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m64 = new Movie();
            m64.MovieNum = 3065;
            m64.Title = "Rain Man";
            m64.Overview = "Selfish yuppie Charlie Babbitt's father left a fortune to his savant brother Raymond and a pittance to Charlie; they travel cross-country.";
            m64.ReleaseDate = new DateTime(1988, 12, 11);
            m64.Revenue = 412800000;
            m64.Runtime = 133;
            m64.Tagline = "A journey through understanding and fellowship.";
            m64.MPAARating = enumMPAARating.R;
            m64.Actors = "Dustin Hoffman, Tom Cruise, Valeria Golino, Gerald R. Molen, Jack Murdock, Michael D. Roberts";
            db.Movies.AddOrUpdate(m => m.Title, m64);
            db.SaveChanges();


            m64 = db.Movies.FirstOrDefault(m => m.MovieNum == m64.MovieNum);
            m64.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m65 = new Movie();
            m65.MovieNum = 3066;
            m65.Title = "Bill & Ted's Excellent Adventure";
            m65.Overview = "In the small town of San Dimas, a few miles away from Los Angeles, there are two nearly brain dead teenage boys going by the names of Bill S, Preston ESQ. and Ted Theodore Logan, they have a dream together of starting their own rock and roll band called the \"Wyld Stallyns\". Unfortunately, they are still in high school and on the verge of failing out of their school as well, and if they do not pass their upcoming history report, they will be separated as a result of Ted's father sending him to military school. But, what Bill and Ted do not know is that they must stay together to save the future. So, a man from the future named Rufus came to help them pass their report. So, both Bill and Ted decided to gather up historical figures which they need for their report. They are hoping that this will help them pass their report so they can stay together.";
            m65.ReleaseDate = new DateTime(1989, 2, 17);
            m65.Revenue = 40485039;
            m65.Runtime = 90;
            m65.Tagline = "History is about to be rewritten by two guys who can't spell.";
            m65.MPAARating = enumMPAARating.PG;
            m65.Actors = "Keanu Reeves, Alex Winter, George Carlin, Dan Shor, Hal Landon Jr., Amy Stock-Poynton";
            db.Movies.AddOrUpdate(m => m.Title, m65);
            db.SaveChanges();


            m65 = db.Movies.FirstOrDefault(m => m.MovieNum == m65.MovieNum);
            m65.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m65.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m65.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m66 = new Movie();
            m66.MovieNum = 3067;
            m66.Title = "Dead Poets Society";
            m66.Overview = "At an elite, old-fashioned boarding school in New England, a passionate English teacher inspires his students to rebel against convention and seize the potential of every day, courting the disdain of the stern headmaster.";
            m66.ReleaseDate = new DateTime(1989, 6, 2);
            m66.Revenue = 235860116;
            m66.Runtime = 129;
            m66.Tagline = "He was their inspiration. He made their lives extraordinary.";
            m66.MPAARating = enumMPAARating.PG;
            m66.Actors = "Robin Williams, Ethan Hawke, Robert Sean Leonard, Gale Hansen, Josh Charles, Dylan Kussman";
            db.Movies.AddOrUpdate(m => m.Title, m66);
            db.SaveChanges();


            m66 = db.Movies.FirstOrDefault(m => m.MovieNum == m66.MovieNum);
            m66.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m67 = new Movie();
            m67.MovieNum = 3068;
            m67.Title = "When Harry Met Sally...";
            m67.Overview = "During their travels from Chicago to New York, Harry and Sally Will debate whether or not sex ruins a perfect relationship between a man and a woman. Eleven years and later, they're still no closer to finding the answer.";
            m67.ReleaseDate = new DateTime(1989, 7, 21);
            m67.Revenue = 92823546;
            m67.Runtime = 96;
            m67.Tagline = "Can two friends sleep together and still love each other in the morning?";
            m67.MPAARating = enumMPAARating.R;
            m67.Actors = "Meg Ryan, Billy Crystal, Carrie Fisher, Bruno Kirby, Steven Ford, Lisa Jane Persky";
            db.Movies.AddOrUpdate(m => m.Title, m67);
            db.SaveChanges();


            m67 = db.Movies.FirstOrDefault(m => m.MovieNum == m67.MovieNum);
            m67.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m67.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m67.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m68 = new Movie();
            m68.MovieNum = 3069;
            m68.Title = "Back to the Future Part II";
            m68.Overview = "Marty and Doc are at it again in this wacky sequel to the 1985 blockbuster as the time-traveling duo head to 2015 to nip some McFly family woes in the bud. But things go awry thanks to bully Biff Tannen and a pesky sports almanac. In a last-ditch attempt to set things straight, Marty finds himself bound for 1955 and face to face with his teenage parents -- again.";
            m68.ReleaseDate = new DateTime(1989, 11, 20);
            m68.Revenue = 332000000;
            m68.Runtime = 108;
            m68.Tagline = "Roads? Where we're going, we don't need roads!";
            m68.MPAARating = enumMPAARating.PG;
            m68.Actors = "Michael J. Fox, Christopher Lloyd, Lea Thompson, Elisabeth Shue, James Tolkan, Jeffrey Weissman";
            db.Movies.AddOrUpdate(m => m.Title, m68);
            db.SaveChanges();


            m68 = db.Movies.FirstOrDefault(m => m.MovieNum == m68.MovieNum);
            m68.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m68.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m68.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m68.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m69 = new Movie();
            m69.MovieNum = 3070;
            m69.Title = "Back to the Future Part III";
            m69.Overview = "The final installment of the Back to the Future trilogy finds Marty digging the trusty DeLorean out of a mineshaft and looking up Doc in the Wild West of 1885. But when their time machine breaks down, the travelers are stranded in a land of spurs. More problems arise when Doc falls for pretty schoolteacher Clara Clayton, and Marty tangles with Buford Tannen.";
            m69.ReleaseDate = new DateTime(1990, 5, 25);
            m69.Revenue = 244527583;
            m69.Runtime = 118;
            m69.Tagline = "They've saved the best trip for last... But this time they may have gone too far.";
            m69.MPAARating = enumMPAARating.PG;
            m69.Actors = "Michael J. Fox, Christopher Lloyd, Mary Steenburgen, Thomas F. Wilson, Lea Thompson, Elisabeth Shue";
            db.Movies.AddOrUpdate(m => m.Title, m69);
            db.SaveChanges();


            m69 = db.Movies.FirstOrDefault(m => m.MovieNum == m69.MovieNum);
            m69.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m69.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m69.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m69.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m70 = new Movie();
            m70.MovieNum = 3071;
            m70.Title = "Robin Hood: Prince of Thieves";
            m70.Overview = "When the dastardly Sheriff of Nottingham murders Robin's father, the legendary archer vows vengeance. To accomplish his mission, Robin joins forces with a band of exiled villagers (and comely Maid Marian), and together they battle to end the evil sheriff's reign of terror.";
            m70.ReleaseDate = new DateTime(1991, 6, 14);
            m70.Revenue = 390493908;
            m70.Runtime = 143;
            m70.Tagline = "For the good of all men, and the love of one woman, he fought to uphold justice by breaking the law.";
            m70.MPAARating = enumMPAARating.PG13;
            m70.Actors = "Kevin Costner, Morgan Freeman, Christian Slater, Mary Elizabeth Mastrantonio, Alan Rickman, Geraldine McEwan";
            db.Movies.AddOrUpdate(m => m.Title, m70);
            db.SaveChanges();


            m70 = db.Movies.FirstOrDefault(m => m.MovieNum == m70.MovieNum);
            m70.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            db.SaveChanges();


            Movie m71 = new Movie();
            m71.MovieNum = 3072;
            m71.Title = "Wayne's World";
            m71.Overview = "When a sleazy TV exec offers Wayne and Garth a fat contract to tape their late-night public access show at his network, they can't believe their good fortune. But they soon discover the road from basement to big-time is a gnarly one, fraught with danger, temptation and ragin' party opportunities.";
            m71.ReleaseDate = new DateTime(1992, 2, 14);
            m71.Revenue = 121697323;
            m71.Runtime = 94;
            m71.Tagline = "You'll laugh. You'll cry. You'll hurl.";
            m71.MPAARating = enumMPAARating.PG13;
            m71.Actors = "Mike Myers, Dana Carvey, Rob Lowe, Tia Carrere, Lara Flynn Boyle, Chris Farley";
            db.Movies.AddOrUpdate(m => m.Title, m71);
            db.SaveChanges();


            m71 = db.Movies.FirstOrDefault(m => m.MovieNum == m71.MovieNum);
            m71.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m72 = new Movie();
            m72.MovieNum = 3073;
            m72.Title = "A League of Their Own";
            m72.Overview = "Small-town sisters Dottie and Kit join an all-female baseball league formed after World War II brings pro baseball to a standstill. When their team hits the road with its drunken coach, the siblings find troubles and triumphs on and off the field.";
            m72.ReleaseDate = new DateTime(1992, 7, 1);
            m72.Revenue = 107458785;
            m72.Runtime = 128;
            m72.Tagline = "To achieve the incredible, you have to attempt the impossible.";
            m72.MPAARating = enumMPAARating.PG;
            m72.Actors = "Tom Hanks, Geena Davis, Madonna, Lori Petty, Jon Lovitz, David Strathairn";
            db.Movies.AddOrUpdate(m => m.Title, m72);
            db.SaveChanges();


            m72 = db.Movies.FirstOrDefault(m => m.MovieNum == m72.MovieNum);
            m72.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m73 = new Movie();
            m73.MovieNum = 3074;
            m73.Title = "The Last of the Mohicans";
            m73.Overview = "As the English and French soldiers battle for control of the American colonies in the 18th century, the settlers and native Americans are forced to take sides. Cora and her sister Alice unwittingly walk into trouble but are reluctantly saved by Hawkeye, an orphaned settler adopted by the last of the Mohicans.";
            m73.ReleaseDate = new DateTime(1992, 9, 25);
            m73.Revenue = 75505856;
            m73.Runtime = 112;
            m73.Tagline = "The first American hero.";
            m73.MPAARating = enumMPAARating.R;
            m73.Actors = "Daniel Day-Lewis, Madeleine Stowe, Russell Means, Eric Schweig, Jodhi May, Steven Waddington";
            db.Movies.AddOrUpdate(m => m.Title, m73);
            db.SaveChanges();


            m73 = db.Movies.FirstOrDefault(m => m.MovieNum == m73.MovieNum);
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "History"));
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m73.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "War"));
            db.SaveChanges();


            Movie m74 = new Movie();
            m74.MovieNum = 3075;
            m74.Title = "Aladdin";
            m74.Overview = "Princess Jasmine grows tired of being forced to remain in the palace and she sneaks out into the marketplace  in disguise where she meets street-urchin Aladdin and the two fall in love, although she may only marry a prince. After being thrown in jail, Aladdin and becomes embroiled in a plot to find a mysterious lamp with which the evil Jafar hopes to rule the land.";
            m74.ReleaseDate = new DateTime(1992, 11, 25);
            m74.Revenue = 504050219;
            m74.Runtime = 90;
            m74.Tagline = "Wish granted!";
            m74.MPAARating = enumMPAARating.G;
            m74.Actors = "Scott Weinger, Robin Williams, Linda Larkin, Jonathan Freeman, Frank Welker, Gilbert Gottfried";
            db.Movies.AddOrUpdate(m => m.Title, m74);
            db.SaveChanges();


            m74 = db.Movies.FirstOrDefault(m => m.MovieNum == m74.MovieNum);
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m74.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m75 = new Movie();
            m75.MovieNum = 3076;
            m75.Title = "The Muppet Christmas Carol";
            m75.Overview = "A retelling of the classic Dickens tale of Ebenezer Scrooge, miser extraordinaire. He is held accountable for his dastardly ways during night-time visitations by the Ghosts of Christmas Past, Present, and future.";
            m75.ReleaseDate = new DateTime(1992, 12, 10);
            m75.Revenue = 27281507;
            m75.Runtime = 85;
            m75.Tagline = "not avaliable";
            m75.MPAARating = enumMPAARating.G;
            m75.Actors = "Michael Caine, Don Austen, Meredith Braun, Don Austen, Ed Sanders, Dave Goelz";
            db.Movies.AddOrUpdate(m => m.Title, m75);
            db.SaveChanges();


            m75 = db.Movies.FirstOrDefault(m => m.MovieNum == m75.MovieNum);
            m75.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m75.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m75.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m75.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m76 = new Movie();
            m76.MovieNum = 3077;
            m76.Title = "A Few Good Men";
            m76.Overview = "When cocky military lawyer Lt. Daniel Kaffee and his co-counsel, Lt. Cmdr. JoAnne Galloway, are assigned to a murder case, they uncover a hazing ritual that could implicate high-ranking officials such as shady Col. Nathan Jessep.";
            m76.ReleaseDate = new DateTime(1992, 12, 11);
            m76.Revenue = 243240178;
            m76.Runtime = 138;
            m76.Tagline = "You can't handle the truth!";
            m76.MPAARating = enumMPAARating.R;
            m76.Actors = "Tom Cruise, Jack Nicholson, Demi Moore, Kevin Bacon, Kevin Pollak, James Marshall";
            db.Movies.AddOrUpdate(m => m.Title, m76);
            db.SaveChanges();


            m76 = db.Movies.FirstOrDefault(m => m.MovieNum == m76.MovieNum);
            m76.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m77 = new Movie();
            m77.MovieNum = 3078;
            m77.Title = "Jurassic Park";
            m77.Overview = "A wealthy entrepreneur secretly creates a theme park featuring living dinosaurs drawn from prehistoric DNA. Before opening day, he invites a team of experts and his two eager grandchildren to experience the park and help calm anxious investors. However, the park is anything but amusing as the security systems go off-line and the dinosaurs escape.";
            m77.ReleaseDate = new DateTime(1993, 6, 11);
            m77.Revenue = 920100000;
            m77.Runtime = 127;
            m77.Tagline = "An adventure 65 million years in the making.";
            m77.MPAARating = enumMPAARating.PG13;
            m77.Actors = "Sam Neill, Laura Dern, Jeff Goldblum, Richard Attenborough, Bob Peck, Martin Ferrero";
            db.Movies.AddOrUpdate(m => m.Title, m77);
            db.SaveChanges();


            m77 = db.Movies.FirstOrDefault(m => m.MovieNum == m77.MovieNum);
            m77.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m77.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m78 = new Movie();
            m78.MovieNum = 3079;
            m78.Title = "Hocus Pocus";
            m78.Overview = "After 300 years of slumber, three sister witches are accidentally resurrected in Salem on Halloween night, and it us up to three kids and their newfound feline friend to put an end to the witches' reign of terror once and for all.";
            m78.ReleaseDate = new DateTime(1993, 7, 16);
            m78.Revenue = 39514713;
            m78.Runtime = 96;
            m78.Tagline = "It's just a bunch of Hocus Pocus.";
            m78.MPAARating = enumMPAARating.PG;
            m78.Actors = "Bette Midler, Sarah Jessica Parker, Kathy Najimy, Omri Katz, Thora Birch, Vinessa Shaw";
            db.Movies.AddOrUpdate(m => m.Title, m78);
            db.SaveChanges();


            m78 = db.Movies.FirstOrDefault(m => m.MovieNum == m78.MovieNum);
            m78.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m78.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m78.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m79 = new Movie();
            m79.MovieNum = 3080;
            m79.Title = "Dazed and Confused";
            m79.Overview = "The adventures of a group of Texas teens on their last day of school in 1976, centering on student Randall Floyd, who moves easily among stoners, jocks and geeks. Floyd is a star athlete, but he also likes smoking weed, which presents a conundrum when his football coach demands he sign a \"no drugs\" pledge.";
            m79.ReleaseDate = new DateTime(1993, 9, 24);
            m79.Revenue = 7993039;
            m79.Runtime = 102;
            m79.Tagline = "See it with a bud.";
            m79.MPAARating = enumMPAARating.R;
            m79.Actors = "Jason London, Rory Cochrane, Wiley Wiggins, Sasha Jenson, Michelle Burke, Adam Goldberg";
            db.Movies.AddOrUpdate(m => m.Title, m79);
            db.SaveChanges();


            m79 = db.Movies.FirstOrDefault(m => m.MovieNum == m79.MovieNum);
            m79.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m79.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m80 = new Movie();
            m80.MovieNum = 3081;
            m80.Title = "Four Weddings and a Funeral";
            m80.Overview = "Four Weddings And A Funeral is a British comedy about a British Man named Charles and an American Woman named Carrie who go through numerous weddings before they determine if they are right for one another.";
            m80.ReleaseDate = new DateTime(1994, 3, 9);
            m80.Revenue = 254700832;
            m80.Runtime = 117;
            m80.Tagline = "Five good reasons to stay single.";
            m80.MPAARating = enumMPAARating.R;
            m80.Actors = "Hugh Grant, Andie MacDowell, James Fleet, Simon Callow, John Hannah, Kristin Scott Thomas";
            db.Movies.AddOrUpdate(m => m.Title, m80);
            db.SaveChanges();


            m80 = db.Movies.FirstOrDefault(m => m.MovieNum == m80.MovieNum);
            m80.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m80.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m80.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m81 = new Movie();
            m81.MovieNum = 3082;
            m81.Title = "The Lion King";
            m81.Overview = "A young lion cub named Simba can't wait to be king. But his uncle craves the title for himself and will stop at nothing to get it.";
            m81.ReleaseDate = new DateTime(1994, 6, 23);
            m81.Revenue = 788241776;
            m81.Runtime = 89;
            m81.Tagline = "Life's greatest adventure is finding your place in the Circle of Life.";
            m81.MPAARating = enumMPAARating.G;
            m81.Actors = "Jonathan Taylor Thomas, Matthew Broderick, James Earl Jones, Jeremy Irons, Moira Kelly, Niketa Calame";
            db.Movies.AddOrUpdate(m => m.Title, m81);
            db.SaveChanges();


            m81 = db.Movies.FirstOrDefault(m => m.MovieNum == m81.MovieNum);
            m81.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m81.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m81.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m82 = new Movie();
            m82.MovieNum = 3083;
            m82.Title = "Forrest Gump";
            m82.Overview = "A man with a low IQ has accomplished great things in his life and been present during significant historic events - in each case, far exceeding what anyone imagined he could do. Yet, despite all the things he has attained, his one true love eludes him. 'Forrest Gump' is the story of a man who rose above his challenges, and who proved that determination, courage, and love are more important than ability.";
            m82.ReleaseDate = new DateTime(1994, 7, 6);
            m82.Revenue = 677945399;
            m82.Runtime = 142;
            m82.Tagline = "The world will never be the same, once you've seen it through the eyes of Forrest Gump.";
            m82.MPAARating = enumMPAARating.PG13;
            m82.Actors = "Tom Hanks, Robin Wright, Gary Sinise, Mykelti Williamson, Sally Field, Michael Conner Humphreys";
            db.Movies.AddOrUpdate(m => m.Title, m82);
            db.SaveChanges();


            m82 = db.Movies.FirstOrDefault(m => m.MovieNum == m82.MovieNum);
            m82.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m82.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m82.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m83 = new Movie();
            m83.MovieNum = 3084;
            m83.Title = "The Shawshank Redemption";
            m83.Overview = "Framed in the 1940s for the double murder of his wife and her lover, upstanding banker Andy Dufresne begins a new life at the Shawshank prison, where he puts his accounting skills to work for an amoral warden. During his long stretch in prison, Dufresne comes to be admired by the other inmates -- including an older prisoner named Red -- for his integrity and unquenchable sense of hope.";
            m83.ReleaseDate = new DateTime(1994, 9, 23);
            m83.Revenue = 28341469;
            m83.Runtime = 142;
            m83.Tagline = "Fear can hold you prisoner. Hope can set you free.";
            m83.MPAARating = enumMPAARating.R;
            m83.Actors = "Tim Robbins, Morgan Freeman, Bob Gunton, Clancy Brown, Mark Rolston, James Whitmore";
            db.Movies.AddOrUpdate(m => m.Title, m83);
            db.SaveChanges();


            m83 = db.Movies.FirstOrDefault(m => m.MovieNum == m83.MovieNum);
            m83.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m83.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m84 = new Movie();
            m84.MovieNum = 3085;
            m84.Title = "Pulp Fiction";
            m84.Overview = "A burger-loving hit man, his philosophical partner, a drug-addled gangster's moll and a washed-up boxer converge in this sprawling, comedic crime caper. Their adventures unfurl in three stories that ingeniously trip back and forth in time.";
            m84.ReleaseDate = new DateTime(1994, 10, 8);
            m84.Revenue = 213928762;
            m84.Runtime = 154;
            m84.Tagline = "Just because you are a character doesn't mean you have character.";
            m84.MPAARating = enumMPAARating.R;
            m84.Actors = "John Travolta, Samuel L. Jackson, Uma Thurman, Bruce Willis, Ving Rhames, Harvey Keitel";
            db.Movies.AddOrUpdate(m => m.Title, m84);
            db.SaveChanges();


            m84 = db.Movies.FirstOrDefault(m => m.MovieNum == m84.MovieNum);
            m84.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            m84.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m85 = new Movie();
            m85.MovieNum = 3086;
            m85.Title = "The Usual Suspects";
            m85.Overview = "Held in an L.A. interrogation room, Verbal Kint attempts to convince the feds that a mythic crime lord, Keyser Soze, not only exists, but was also responsible for drawing him and his four partners into a multi-million dollar heist that ended with an explosion in San Pedro harbor ???? leaving few survivors. Verbal lures his interrogators with an incredible story of the crime lord's almost supernatural prowess.";
            m85.ReleaseDate = new DateTime(1995, 7, 19);
            m85.Revenue = 23341568;
            m85.Runtime = 106;
            m85.Tagline = "Five Criminals. One Line Up. No Coincidence.";
            m85.MPAARating = enumMPAARating.R;
            m85.Actors = "Stephen Baldwin, Gabriel Byrne, Chazz Palminteri, Kevin Pollak, Pete Postlethwaite, Kevin Spacey";
            db.Movies.AddOrUpdate(m => m.Title, m85);
            db.SaveChanges();


            m85 = db.Movies.FirstOrDefault(m => m.MovieNum == m85.MovieNum);
            m85.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m85.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m85.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m86 = new Movie();
            m86.MovieNum = 3087;
            m86.Title = "Toy Story";
            m86.Overview = "Led by Woody, Andy's toys live happily in his room until Andy's birthday brings Buzz Lightyear onto the scene. Afraid of losing his place in Andy's heart, Woody plots against Buzz. But when circumstances separate Buzz and Woody from their owner, the duo eventually learns to put aside their differences.";
            m86.ReleaseDate = new DateTime(1995, 10, 30);
            m86.Revenue = 373554033;
            m86.Runtime = 81;
            m86.Tagline = "Hang on for the comedy that goes to infinity and beyond!";
            m86.MPAARating = enumMPAARating.G;
            m86.Actors = "Tom Hanks, Tim Allen, Don Rickles, Jim Varney, Wallace Shawn, John Ratzenberger";
            db.Movies.AddOrUpdate(m => m.Title, m86);
            db.SaveChanges();


            m86 = db.Movies.FirstOrDefault(m => m.MovieNum == m86.MovieNum);
            m86.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m86.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m86.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m87 = new Movie();
            m87.MovieNum = 3088;
            m87.Title = "Sense and Sensibility";
            m87.Overview = "Rich Mr. Dashwood dies, leaving his second wife and her daughters poor by the rules of inheritance. Two daughters are the titular opposites.";
            m87.ReleaseDate = new DateTime(1995, 12, 13);
            m87.Revenue = 135000000;
            m87.Runtime = 136;
            m87.Tagline = "Lose your heart and come to your senses.";
            m87.MPAARating = enumMPAARating.PG;
            m87.Actors = "Kate Winslet, Emma Thompson, Hugh Grant, Tom Wilkinson, Alan Rickman, Imogen Stubbs";
            db.Movies.AddOrUpdate(m => m.Title, m87);
            db.SaveChanges();


            m87 = db.Movies.FirstOrDefault(m => m.MovieNum == m87.MovieNum);
            m87.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m87.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m88 = new Movie();
            m88.MovieNum = 3089;
            m88.Title = "Mission: Impossible";
            m88.Overview = "When Ethan Hunt, the leader of a crack espionage team whose perilous operation has gone awry with no explanation, discovers that a mole has penetrated the CIA, he's surprised to learn that he's the No. 1 suspect. To clear his name, Hunt now must ferret out the real double agent and, in the process, even the score.";
            m88.ReleaseDate = new DateTime(1996, 5, 22);
            m88.Revenue = 457696359;
            m88.Runtime = 110;
            m88.Tagline = "Expect the Impossible.";
            m88.MPAARating = enumMPAARating.PG13;
            m88.Actors = "Tom Cruise, Jon Voight, Emmanuelle Beart, Henry Czerny, Jean Reno, Ving Rhames";
            db.Movies.AddOrUpdate(m => m.Title, m88);
            db.SaveChanges();


            m88 = db.Movies.FirstOrDefault(m => m.MovieNum == m88.MovieNum);
            m88.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m88.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m88.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m89 = new Movie();
            m89.MovieNum = 3090;
            m89.Title = "Independence Day";
            m89.Overview = "On July 2, a giant alien mothership enters orbit around Earth and deploys several dozen saucer-shaped 'destroyer' spacecraft that quickly lay waste to major cities around the planet. On July 3, the United States conducts a coordinated counterattack that fails. On July 4, a plan is devised to gain access to the interior of the alien mothership in space, in order to plant a nuclear missile.";
            m89.ReleaseDate = new DateTime(1996, 6, 25);
            m89.Revenue = 816969268;
            m89.Runtime = 145;
            m89.Tagline = "Earth. Take a good look. It might be your last.";
            m89.MPAARating = enumMPAARating.PG13;
            m89.Actors = "Will Smith, Bill Pullman, Jeff Goldblum, Mary McDonnell, Judd Hirsch, Robert Loggia";
            db.Movies.AddOrUpdate(m => m.Title, m89);
            db.SaveChanges();


            m89 = db.Movies.FirstOrDefault(m => m.MovieNum == m89.MovieNum);
            m89.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m89.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m89.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m90 = new Movie();
            m90.MovieNum = 3091;
            m90.Title = "Austin Powers: International Man of Mystery";
            m90.Overview = "As a swingin' fashion photographer by day and a groovy British superagent by night, Austin Powers is the '60s' most shagadelic spy, baby! But can he stop megalomaniac Dr. Evil after the bald villain freezes himself and unthaws in the '90s? With the help of sexy sidekick Vanessa Kensington, he just might.";
            m90.ReleaseDate = new DateTime(1997, 5, 2);
            m90.Revenue = 67683989;
            m90.Runtime = 94;
            m90.Tagline = "If he were any cooler, he'd still be frozen, baby!";
            m90.MPAARating = enumMPAARating.PG13;
            m90.Actors = "Mike Myers, Elizabeth Hurley, Michael York, Mimi Rogers, Seth Green, Fabiana Udenio";
            db.Movies.AddOrUpdate(m => m.Title, m90);
            db.SaveChanges();


            m90 = db.Movies.FirstOrDefault(m => m.MovieNum == m90.MovieNum);
            m90.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m90.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m90.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m91 = new Movie();
            m91.MovieNum = 3092;
            m91.Title = "Men in Black";
            m91.Overview = "Men in Black follows the exploits of agents Kay and Jay, members of a top-secret organization established to monitor and police alien activity on Earth. The two Men in Black find themselves in the middle of the deadly plot by an intergalactic terrorist who has arrived on Earth to assassinate two ambassadors from opposing galaxies. In order to prevent worlds from colliding, the MiB must track down the terrorist and prevent the destruction of Earth. It's just another typical day for the Men in Black.";
            m91.ReleaseDate = new DateTime(1997, 7, 2);
            m91.Revenue = 589390539;
            m91.Runtime = 98;
            m91.Tagline = "Protecting the Earth from the scum of the universe.";
            m91.MPAARating = enumMPAARating.PG13;
            m91.Actors = "Tommy Lee Jones, Will Smith, Linda Fiorentino, Vincent D'Onofrio, Rip Torn, Tony Shalhoub";
            db.Movies.AddOrUpdate(m => m.Title, m91);
            db.SaveChanges();


            m91 = db.Movies.FirstOrDefault(m => m.MovieNum == m91.MovieNum);
            m91.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m91.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m91.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m91.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m92 = new Movie();
            m92.MovieNum = 3093;
            m92.Title = "Titanic";
            m92.Overview = "84 years later, a 101-year-old woman named Rose DeWitt Bukater tells the story to her granddaughter Lizzy Calvert, Brock Lovett, Lewis Bodine, Bobby Buell and Anatoly Mikailavich on the Keldysh about her life set in April 10th 1912, on a ship called Titanic when young Rose boards the departing ship with the upper-class passengers and her mother, Ruth DeWitt Bukater, and her fianc??, Caledon Hockley. Meanwhile, a drifter and artist named Jack Dawson and his best friend Fabrizio De Rossi win third-class tickets to the ship in a game. And she explains the whole story from departure until the death of Titanic on its first and last voyage April 15th, 1912 at 2:20 in the morning.";
            m92.ReleaseDate = new DateTime(1997, 11, 18);
            m92.Revenue = 1845034188;
            m92.Runtime = 194;
            m92.Tagline = "Nothing on Earth could come between them.";
            m92.MPAARating = enumMPAARating.PG13;
            m92.Actors = "Kate Winslet, Leonardo DiCaprio, Frances Fisher, Billy Zane, Kathy Bates, Gloria Stuart";
            db.Movies.AddOrUpdate(m => m.Title, m92);
            db.SaveChanges();


            m92 = db.Movies.FirstOrDefault(m => m.MovieNum == m92.MovieNum);
            m92.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m92.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m92.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m93 = new Movie();
            m93.MovieNum = 3094;
            m93.Title = "The Big Lebowski";
            m93.Overview = "Jeffrey \"The Dude\" Lebowski, a Los Angeles slacker who only wants to bowl and drink white Russians, is mistaken for another Jeffrey Lebowski, a wheelchair-bound millionaire, and finds himself dragged into a strange series of events involving nihilists, adult film producers, ferrets, errant toes, and large sums of money.";
            m93.ReleaseDate = new DateTime(1998, 3, 6);
            m93.Revenue = 46189568;
            m93.Runtime = 117;
            m93.Tagline = "Times like these call for a Big Lebowski.";
            m93.MPAARating = enumMPAARating.R;
            m93.Actors = "Jeff Bridges, John Goodman, Julianne Moore, Steve Buscemi, Philip Seymour Hoffman, David Huddleston";
            db.Movies.AddOrUpdate(m => m.Title, m93);
            db.SaveChanges();


            m93 = db.Movies.FirstOrDefault(m => m.MovieNum == m93.MovieNum);
            m93.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m93.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m94 = new Movie();
            m94.MovieNum = 3095;
            m94.Title = "Shakespeare in Love";
            m94.Overview = "Young Shakespeare is forced to stage his latest comedy, \"Romeo and Ethel, the Pirate's Daughter,\" before it's even written.When a lovely noblewoman auditions for a role, they fall into forbidden love-- and his play finds a new life(and title).As their relationship progresses, Shakespeare's comedy soon transforms into tragedy.";
            m94.ReleaseDate = new DateTime(1998, 12, 11);
            m94.Revenue = 289317794;
            m94.Runtime = 122;
            m94.Tagline = "Love is the only inspiration.";
            m94.MPAARating = enumMPAARating.R;
            m94.Actors = "Joseph Fiennes, Gwyneth Paltrow, Geoffrey Rush, Tom Wilkinson, Judi Dench, Imelda Staunton";
            db.Movies.AddOrUpdate(m => m.Title, m94);
            db.SaveChanges();


            m94 = db.Movies.FirstOrDefault(m => m.MovieNum == m94.MovieNum);
            m94.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m94.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "History"));
            db.SaveChanges();


            Movie m95 = new Movie();
            m95.MovieNum = 3096;
            m95.Title = "You've Got Mail";
            m95.Overview = "Book superstore magnate, Joe Fox and independent book shop owner, Kathleen Kelly fall in love in the anonymity of the Internet ???? both blissfully unaware that he's putting her out of business.";
            m95.ReleaseDate = new DateTime(1998, 12, 17);
            m95.Revenue = 250821495;
            m95.Runtime = 119;
            m95.Tagline = "Someone you pass on the street may already be the love of your life.";
            m95.MPAARating = enumMPAARating.PG;
            m95.Actors = "Tom Hanks, Meg Ryan, Katie Sagona, Greg Kinnear, Parker Posey, Jean Stapleton";
            db.Movies.AddOrUpdate(m => m.Title, m95);
            db.SaveChanges();


            m95 = db.Movies.FirstOrDefault(m => m.MovieNum == m95.MovieNum);
            m95.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m95.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m96 = new Movie();
            m96.MovieNum = 3097;
            m96.Title = "Office Space";
            m96.Overview = "Three office workers strike back at their evil employers by hatching a hapless attempt to embezzle money.";
            m96.ReleaseDate = new DateTime(1999, 2, 19);
            m96.Revenue = 12827813;
            m96.Runtime = 89;
            m96.Tagline = "Work sucks.";
            m96.MPAARating = enumMPAARating.R;
            m96.Actors = "Ron Livingston, Jennifer Aniston, David Herman, Ajay Naidu, Diedrich Bader, Stephen Root";
            db.Movies.AddOrUpdate(m => m.Title, m96);
            db.SaveChanges();


            m96 = db.Movies.FirstOrDefault(m => m.MovieNum == m96.MovieNum);
            m96.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m96.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m97 = new Movie();
            m97.MovieNum = 3098;
            m97.Title = "Notting Hill";
            m97.Overview = "The British comedy from director Roger Michell tells the love story between a famous actress and a simple book seller from London. A look into the attempt for famous people to have a personal and private life and the ramifications that follow. Nominated for three Golden Globes in 2000.";
            m97.ReleaseDate = new DateTime(1999, 5, 13);
            m97.Revenue = 363889678;
            m97.Runtime = 124;
            m97.Tagline = "Can the most famous film star in the world fall for the man on the street?";
            m97.MPAARating = enumMPAARating.PG13;
            m97.Actors = "Julia Roberts, Hugh Grant, Gina McKee, Tim McInnerny, Rhys Ifans, Emma Chambers";
            db.Movies.AddOrUpdate(m => m.Title, m97);
            db.SaveChanges();


            m97 = db.Movies.FirstOrDefault(m => m.MovieNum == m97.MovieNum);
            m97.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m97.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m97.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m98 = new Movie();
            m98.MovieNum = 3099;
            m98.Title = "Toy Story 2";
            m98.Overview = "Andy heads off to Cowboy Camp, leaving his toys to their own devices. Things shift into high gear when an obsessive toy collector named Al McWhiggen, owner of Al's Toy Barn kidnaps Woody. Andy's toys mount a daring rescue mission, Buzz Lightyear meets his match and Woody has to decide where he and his heart truly belong.";
            m98.ReleaseDate = new DateTime(1999, 10, 30);
            m98.Revenue = 497366869;
            m98.Runtime = 92;
            m98.Tagline = "The toys are back!";
            m98.MPAARating = enumMPAARating.G;
            m98.Actors = "Tom Hanks, Tim Allen, Joan Cusack, Kelsey Grammer, Don Rickles, Jim Varney";
            db.Movies.AddOrUpdate(m => m.Title, m98);
            db.SaveChanges();


            m98 = db.Movies.FirstOrDefault(m => m.MovieNum == m98.MovieNum);
            m98.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m98.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m98.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m99 = new Movie();
            m99.MovieNum = 3100;
            m99.Title = "Gladiator";
            m99.Overview = "In the year 180, the death of emperor Marcus Aurelius throws the Roman Empire into chaos. Maximus is one of the Roman army's most capable and trusted generals and a key advisor to the emperor. As Marcus' devious son Commodus ascends to the throne, Maximus is set to be executed. He escapes, but is captured by slave traders. Renamed Spaniard and forced to become a gladiator, Maximus must battle to the death with other men for the amusement of paying audiences. His battle skills serve him well, and he becomes one of the most famous and admired men to fight in the Colosseum. Determined to avenge himself against the man who took away his freedom and laid waste to his family, Maximus believes that he can use his fame and skill in the ring to avenge the loss of his family and former glory. As the gladiator begins to challenge his rule, Commodus decides to put his own fighting mettle to the test by squaring off with Maximus in a battle to the death.";
            m99.ReleaseDate = new DateTime(2000, 5, 1);
            m99.Revenue = 457640427;
            m99.Runtime = 155;
            m99.Tagline = "A Hero Will Rise.";
            m99.MPAARating = enumMPAARating.R;
            m99.Actors = "Russell Crowe, Joaquin Phoenix, Connie Nielsen, Oliver Reed, Richard Harris, Derek Jacobi";
            db.Movies.AddOrUpdate(m => m.Title, m99);
            db.SaveChanges();


            m99 = db.Movies.FirstOrDefault(m => m.MovieNum == m99.MovieNum);
            m99.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m99.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m99.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            db.SaveChanges();


            Movie m100 = new Movie();
            m100.MovieNum = 3101;
            m100.Title = "Gone in Sixty Seconds";
            m100.Overview = "Upon learning that he has to come out of retirement to steal 50 cars in one night to save his brother Kip's life, former car thief Randall \"Memphis\" Raines enlists help from a few \"boost happy\" pals to accomplish a seemingly impossible feat. From countless car chases to relentless cops, the high-octane excitement builds as Randall swerves around more than a few roadblocks to keep Kip alive.";
            m100.ReleaseDate = new DateTime(2000, 6, 9);
            m100.Revenue = 237202299;
            m100.Runtime = 118;
            m100.Tagline = "Ice Cold, Hot Wired.";
            m100.MPAARating = enumMPAARating.PG13;
            m100.Actors = "Nicolas Cage, Angelina Jolie, Giovanni Ribisi, Delroy Lindo, Will Patton, Christopher Eccleston";
            db.Movies.AddOrUpdate(m => m.Title, m100);
            db.SaveChanges();


            m100 = db.Movies.FirstOrDefault(m => m.MovieNum == m100.MovieNum);
            m100.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m100.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m100.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m101 = new Movie();
            m101.MovieNum = 3102;
            m101.Title = "X-Men";
            m101.Overview = "Two mutants, Rogue and Wolverine, come to a private academy for their kind whose resident superhero team, the X-Men, must oppose a terrorist organization with similar powers.";
            m101.ReleaseDate = new DateTime(2000, 7, 13);
            m101.Revenue = 296339527;
            m101.Runtime = 104;
            m101.Tagline = "Evolution Begins";
            m101.MPAARating = enumMPAARating.PG13;
            m101.Actors = "Patrick Stewart, Hugh Jackman, Ian McKellen, Halle Berry, Famke Janssen, James Marsden";
            db.Movies.AddOrUpdate(m => m.Title, m101);
            db.SaveChanges();


            m101 = db.Movies.FirstOrDefault(m => m.MovieNum == m101.MovieNum);
            m101.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m101.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m101.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m102 = new Movie();
            m102.MovieNum = 3103;
            m102.Title = "Miss Congeniality";
            m102.Overview = "When the local FBI office receives a letter from a terrorist known only as 'The Citizen', it's quickly determined that he's planning his next act at the Miss America beauty pageant. Because tough-as-nails Gracie Hart is the only female Agent at the office, she's chosen to go undercover as the contestant from New Jersey.";
            m102.ReleaseDate = new DateTime(2000, 12, 14);
            m102.Revenue = 212000000;
            m102.Runtime = 111;
            m102.Tagline = "Never Mess With An Agent In A Dress.";
            m102.MPAARating = enumMPAARating.PG13;
            m102.Actors = "Sandra Bullock, Benjamin Bratt, Michael Caine, Candice Bergen, William Shatner, Ernie Hudson";
            db.Movies.AddOrUpdate(m => m.Title, m102);
            db.SaveChanges();


            m102 = db.Movies.FirstOrDefault(m => m.MovieNum == m102.MovieNum);
            m102.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m102.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m102.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            db.SaveChanges();


            Movie m103 = new Movie();
            m103.MovieNum = 3104;
            m103.Title = "Bridget Jones's Diary";
            m103.Overview = "A chaotic Bridget Jones meets a snobbish lawyer, and he soon enters her world of imperfections.";
            m103.ReleaseDate = new DateTime(2001, 4, 13);
            m103.Revenue = 281929795;
            m103.Runtime = 97;
            m103.Tagline = "Health Warning: Adopting Bridget's lifestyle could seriously damage your health.";
            m103.MPAARating = enumMPAARating.R;
            m103.Actors = "Renee Zellweger, Colin Firth, Hugh Grant, Gemma Jones, Jim Broadbent, James Callis";
            db.Movies.AddOrUpdate(m => m.Title, m103);
            db.SaveChanges();


            m103 = db.Movies.FirstOrDefault(m => m.MovieNum == m103.MovieNum);
            m103.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m103.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m103.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m104 = new Movie();
            m104.MovieNum = 3105;
            m104.Title = "Legally Blonde";
            m104.Overview = "Elle Woods has it all. She's the president of her sorority, a Hawaiian Tropic girl, Miss June in her campus calendar, and, above all, a natural blonde. She dates the cutest fraternity boy on campus and wants nothing more than to be Mrs. Warner Huntington III. But, there's just one thing stopping Warner from popping the question: Elle is too blonde.";
            m104.ReleaseDate = new DateTime(2001, 7, 13);
            m104.Revenue = 141774679;
            m104.Runtime = 96;
            m104.Tagline = "Don't judge a book by its hair color!";
            m104.MPAARating = enumMPAARating.PG13;
            m104.Actors = "Reese Witherspoon, Luke Wilson, Selma Blair, Matthew Davis, Victor Garber, Jennifer Coolidge";
            db.Movies.AddOrUpdate(m => m.Title, m104);
            db.SaveChanges();


            m104 = db.Movies.FirstOrDefault(m => m.MovieNum == m104.MovieNum);
            m104.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m105 = new Movie();
            m105.MovieNum = 3106;
            m105.Title = "Monsters, Inc.";
            m105.Overview = "James Sullivan and Mike Wazowski are monsters, they earn their living scaring children and are the best in the business... even though they're more afraid of the children than they are of them. When a child accidentally enters their world, James and Mike suddenly find that kids are not to be afraid of and they uncover a conspiracy that could threaten all children across the world.";
            m105.ReleaseDate = new DateTime(2001, 11, 1);
            m105.Revenue = 562816256;
            m105.Runtime = 92;
            m105.Tagline = "We Scare Because We Care.";
            m105.MPAARating = enumMPAARating.G;
            m105.Actors = "John Goodman, Billy Crystal, Mary Gibbs, Steve Buscemi, James Coburn, Jennifer Tilly";
            db.Movies.AddOrUpdate(m => m.Title, m105);
            db.SaveChanges();


            m105 = db.Movies.FirstOrDefault(m => m.MovieNum == m105.MovieNum);
            m105.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m105.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m105.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m106 = new Movie();
            m106.MovieNum = 3107;
            m106.Title = "Harry Potter and the Philosopher's Stone";
            m106.Overview = "Harry Potter has lived under the stairs at his aunt and uncle's house his whole life. But on his 11th birthday, he learns he's a powerful wizard -- with a place waiting for him at the Hogwarts School of Witchcraft and Wizardry. As he learns to harness his newfound powers with the help of the school's kindly headmaster, Harry uncovers the truth about his parents' deaths -- and about the villain who's to blame.";
            m106.ReleaseDate = new DateTime(2001, 11, 16);
            m106.Revenue = 976475550;
            m106.Runtime = 152;
            m106.Tagline = "Let the Magic Begin.";
            m106.MPAARating = enumMPAARating.PG;
            m106.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Richard Harris, Tom Felton, Robbie Coltrane";
            db.Movies.AddOrUpdate(m => m.Title, m106);
            db.SaveChanges();


            m106 = db.Movies.FirstOrDefault(m => m.MovieNum == m106.MovieNum);
            m106.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m106.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m106.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m107 = new Movie();
            m107.MovieNum = 3108;
            m107.Title = "Ocean's Eleven";
            m107.Overview = "Less than 24 hours into his parole, charismatic thief Danny Ocean is already rolling out his next plan: In one night, Danny's hand-picked crew of specialists will attempt to steal more than $150 million from three Las Vegas casinos. But to score the cash, Danny risks his chances of reconciling with ex-wife, Tess.";
            m107.ReleaseDate = new DateTime(2001, 12, 7);
            m107.Revenue = 450717150;
            m107.Runtime = 116;
            m107.Tagline = "Are you in or out?";
            m107.MPAARating = enumMPAARating.PG13;
            m107.Actors = "George Clooney, Brad Pitt, Matt Damon, Andy Garcia, Julia Roberts, Casey Affleck";
            db.Movies.AddOrUpdate(m => m.Title, m107);
            db.SaveChanges();


            m107 = db.Movies.FirstOrDefault(m => m.MovieNum == m107.MovieNum);
            m107.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            m107.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m108 = new Movie();
            m108.MovieNum = 3109;
            m108.Title = "Harry Potter and the Chamber of Secrets";
            m108.Overview = "Ignoring threats to his life, Harry returns to Hogwarts to investigate ???? aided by Ron and Hermione ???? a mysterious series of attacks.";
            m108.ReleaseDate = new DateTime(2002, 11, 13);
            m108.Revenue = 876688482;
            m108.Runtime = 161;
            m108.Tagline = "Hogwarts is back in session.";
            m108.MPAARating = enumMPAARating.PG;
            m108.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Richard Harris, Alan Rickman, Tom Felton";
            db.Movies.AddOrUpdate(m => m.Title, m108);
            db.SaveChanges();


            m108 = db.Movies.FirstOrDefault(m => m.MovieNum == m108.MovieNum);
            m108.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m108.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m108.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m109 = new Movie();
            m109.MovieNum = 3110;
            m109.Title = "Finding Nemo";
            m109.Overview = "Nemo, an adventurous young clownfish, is unexpectedly taken from his Great Barrier Reef home to a dentist's office aquarium. It's up to his worrisome father Marlin and a friendly but forgetful fish Dory to bring Nemo home -- meeting vegetarian sharks, surfer dude turtles, hypnotic jellyfish, hungry seagulls, and more along the way.";
            m109.ReleaseDate = new DateTime(2003, 5, 30);
            m109.Revenue = 940335536;
            m109.Runtime = 100;
            m109.Tagline = "There are 3.7 trillion fish in the ocean, they're looking for one.";
            m109.MPAARating = enumMPAARating.G;
            m109.Actors = "Albert Brooks, Ellen DeGeneres, Alexander Gould, Willem Dafoe, Brad Garrett, Allison Janney";
            db.Movies.AddOrUpdate(m => m.Title, m109);
            db.SaveChanges();


            m109 = db.Movies.FirstOrDefault(m => m.MovieNum == m109.MovieNum);
            m109.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m109.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m110 = new Movie();
            m110.MovieNum = 3111;
            m110.Title = "Love Actually";
            m110.Overview = "Follows seemingly unrelated people as their lives begin to intertwine while they fall in ???? and out ???? of love. Affections languish and develop as Christmas draws near.";
            m110.ReleaseDate = new DateTime(2003, 9, 7);
            m110.Revenue = 244931766;
            m110.Runtime = 135;
            m110.Tagline = "The ultimate romantic comedy.";
            m110.MPAARating = enumMPAARating.R;
            m110.Actors = "Keira Knightley, Heike Makatsch, Emma Thompson, Laura Linney, Hugh Grant, January Jones";
            db.Movies.AddOrUpdate(m => m.Title, m110);
            db.SaveChanges();


            m110 = db.Movies.FirstOrDefault(m => m.MovieNum == m110.MovieNum);
            m110.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m110.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m110.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m111 = new Movie();
            m111.MovieNum = 3112;
            m111.Title = "Elf";
            m111.Overview = "When young Buddy falls into Santa's gift sack on Christmas Eve, he's transported back to the North Pole and raised as a toy-making elf by Santa's helpers. But as he grows into adulthood, he can't shake the nagging feeling that he doesn't belong. Buddy vows to visit Manhattan and find his real dad, a workaholic publisher.";
            m111.ReleaseDate = new DateTime(2003, 10, 9);
            m111.Revenue = 173398518;
            m111.Runtime = 97;
            m111.Tagline = "This holiday, discover your inner elf.";
            m111.MPAARating = enumMPAARating.PG;
            m111.Actors = "Will Ferrell, James Caan, Zooey Deschanel, Mary Steenburgen, Daniel Tay, Ed Asner";
            db.Movies.AddOrUpdate(m => m.Title, m111);
            db.SaveChanges();


            m111 = db.Movies.FirstOrDefault(m => m.MovieNum == m111.MovieNum);
            m111.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m111.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m111.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m112 = new Movie();
            m112.MovieNum = 3113;
            m112.Title = "Mean Girls";
            m112.Overview = "Cady Heron is a hit with The Plastics, the A-list girl clique at her new school, until she makes the mistake of falling for Aaron Samuels, the ex-boyfriend of alpha Plastic Regina George.";
            m112.ReleaseDate = new DateTime(2004, 4, 30);
            m112.Revenue = 129042871;
            m112.Runtime = 97;
            m112.Tagline = "Welcome to girl world.";
            m112.MPAARating = enumMPAARating.PG13;
            m112.Actors = "Lindsay Lohan, Rachel McAdams, Tim Meadows, Ana Gasteyer, Amy Poehler, Tina Fey";
            db.Movies.AddOrUpdate(m => m.Title, m112);
            db.SaveChanges();


            m112 = db.Movies.FirstOrDefault(m => m.MovieNum == m112.MovieNum);
            m112.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m113 = new Movie();
            m113.MovieNum = 3114;
            m113.Title = "Harry Potter and the Prisoner of Azkaban";
            m113.Overview = "Harry, Ron and Hermione return to Hogwarts for another magic-filled year. Harry comes face to face with danger yet again, this time in the form of escaped convict, Sirius Black ???? and turns to sympathetic Professor Lupin for help.";
            m113.ReleaseDate = new DateTime(2004, 5, 31);
            m113.Revenue = 789804554;
            m113.Runtime = 141;
            m113.Tagline = "Something wicked this way comes.";
            m113.MPAARating = enumMPAARating.PG13;
            m113.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Gary Oldman, David Thewlis, Alan Rickman";
            db.Movies.AddOrUpdate(m => m.Title, m113);
            db.SaveChanges();


            m113 = db.Movies.FirstOrDefault(m => m.MovieNum == m113.MovieNum);
            m113.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m113.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m113.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m114 = new Movie();
            m114.MovieNum = 3115;
            m114.Title = "Harry Potter and the Goblet of Fire";
            m114.Overview = "Harry starts his fourth year at Hogwarts, competes in the treacherous Triwizard Tournament and faces the evil Lord Voldemort. Ron and Hermione help Harry manage the pressure ???? but Voldemort lurks, awaiting his chance to destroy Harry and all that he stands for.";
            m114.ReleaseDate = new DateTime(2005, 11, 5);
            m114.Revenue = 895921036;
            m114.Runtime = 157;
            m114.Tagline = "Dark And Difficult Times Lie Ahead.";
            m114.MPAARating = enumMPAARating.PG13;
            m114.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Ralph Fiennes, Michael Gambon, Alan Rickman";
            db.Movies.AddOrUpdate(m => m.Title, m114);
            db.SaveChanges();


            m114 = db.Movies.FirstOrDefault(m => m.MovieNum == m114.MovieNum);
            m114.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m114.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m114.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m115 = new Movie();
            m115.MovieNum = 3116;
            m115.Title = "Cars";
            m115.Overview = "Lightning McQueen, a hotshot rookie race car driven to succeed, discovers that life is about the journey, not the finish line, when he finds himself unexpectedly detoured in the sleepy Route 66 town of Radiator Springs. On route across the country to the big Piston Cup Championship in California to compete against two seasoned pros, McQueen gets to know the town's offbeat characters.";
            m115.ReleaseDate = new DateTime(2006, 6, 8);
            m115.Revenue = 461983149;
            m115.Runtime = 117;
            m115.Tagline = "Ahhh... it's got that new movie smell.";
            m115.MPAARating = enumMPAARating.G;
            m115.Actors = "Owen Wilson, Paul Newman, Bonnie Hunt, Larry the Cable Guy, Tony Shalhoub, Cheech Marin";
            db.Movies.AddOrUpdate(m => m.Title, m115);
            db.SaveChanges();


            m115 = db.Movies.FirstOrDefault(m => m.MovieNum == m115.MovieNum);
            m115.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m115.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m115.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m115.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m116 = new Movie();
            m116.MovieNum = 3117;
            m116.Title = "The Departed";
            m116.Overview = "To take down South Boston's Irish Mafia, the police send in one of their own to infiltrate the underworld, not realizing the syndicate has done likewise. While an undercover cop curries favor with the mob kingpin, a career criminal rises through the police ranks. But both sides soon discover there's a mole among them.";
            m116.ReleaseDate = new DateTime(2006, 10, 5);
            m116.Revenue = 289847354;
            m116.Runtime = 151;
            m116.Tagline = "Lies. Betrayal. Sacrifice. How far will you take it?";
            m116.MPAARating = enumMPAARating.R;
            m116.Actors = "Jack Nicholson, Matt Damon, Jack Nicholson, Mark Wahlberg, Martin Sheen, Ray Winstone";
            db.Movies.AddOrUpdate(m => m.Title, m116);
            db.SaveChanges();


            m116 = db.Movies.FirstOrDefault(m => m.MovieNum == m116.MovieNum);
            m116.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m116.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            m116.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            db.SaveChanges();


            Movie m117 = new Movie();
            m117.MovieNum = 3118;
            m117.Title = "Ratatouille";
            m117.Overview = "A rat named Remy dreams of becoming a great French chef despite his family's wishes and the obvious problem of being a rat in a decidedly rodent-phobic profession. When fate places Remy in the sewers of Paris, he finds himself ideally situated beneath a restaurant made famous by his culinary hero, Auguste Gusteau. Despite the apparent dangers of being an unlikely - and certainly unwanted - visitor in the kitchen of a fine French restaurant, Remy's passion for cooking soon sets into motion a hilarious and exciting rat race that turns the culinary world of Paris upside down.";
            m117.ReleaseDate = new DateTime(2007, 6, 22);
            m117.Revenue = 623722818;
            m117.Runtime = 111;
            m117.Tagline = "He's dying to become a chef.";
            m117.MPAARating = enumMPAARating.G;
            m117.Actors = "Patton Oswalt, Ian Holm, Lou Romano, Brian Dennehy, Peter Sohn, Peter O'Toole";
            db.Movies.AddOrUpdate(m => m.Title, m117);
            db.SaveChanges();


            m117 = db.Movies.FirstOrDefault(m => m.MovieNum == m117.MovieNum);
            m117.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m117.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m117.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m117.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m118 = new Movie();
            m118.MovieNum = 3119;
            m118.Title = "Transformers";
            m118.Overview = "Young teenager, Sam Witwicky becomes involved in the ancient struggle between two extraterrestrial factions of transforming robots ???? the heroic Autobots and the evil Decepticons. Sam holds the clue to unimaginable power and the Decepticons will stop at nothing to retrieve it.";
            m118.ReleaseDate = new DateTime(2007, 6, 27);
            m118.Revenue = 709709780;
            m118.Runtime = 144;
            m118.Tagline = "Their war. Our world.";
            m118.MPAARating = enumMPAARating.PG13;
            m118.Actors = "Shia LaBeouf, Josh Duhamel, Megan Fox, Rachael Taylor, Tyrese Gibson, Jon Voight";
            db.Movies.AddOrUpdate(m => m.Title, m118);
            db.SaveChanges();


            m118 = db.Movies.FirstOrDefault(m => m.MovieNum == m118.MovieNum);
            m118.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m118.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m118.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            db.SaveChanges();


            Movie m119 = new Movie();
            m119.MovieNum = 3120;
            m119.Title = "Harry Potter and the Order of the Phoenix";
            m119.Overview = "Returning for his fifth year of study at Hogwarts, Harry is stunned to find that his warnings about the return of Lord Voldemort have been ignored. Left with no choice, Harry takes matters into his own hands, training a small group of students ???? dubbed 'Dumbledore's Army' ???? to defend themselves against the dark arts.";
            m119.ReleaseDate = new DateTime(2007, 6, 28);
            m119.Revenue = 938212738;
            m119.Runtime = 138;
            m119.Tagline = "Evil Must Be Confronted.";
            m119.MPAARating = enumMPAARating.PG13;
            m119.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Michael Gambon, Ralph Fiennes, Tom Felton";
            db.Movies.AddOrUpdate(m => m.Title, m119);
            db.SaveChanges();


            m119 = db.Movies.FirstOrDefault(m => m.MovieNum == m119.MovieNum);
            m119.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m119.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m119.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m119.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Mystery"));
            db.SaveChanges();


            Movie m120 = new Movie();
            m120.MovieNum = 3121;
            m120.Title = "The Dark Knight";
            m120.Overview = "Batman raises the stakes in his war on crime. With the help of Lt. Jim Gordon and District Attorney Harvey Dent, Batman sets out to dismantle the remaining criminal organizations that plague the streets. The partnership proves to be effective, but they soon find themselves prey to a reign of chaos unleashed by a rising criminal mastermind known to the terrified citizens of Gotham as the Joker.";
            m120.ReleaseDate = new DateTime(2008, 7, 16);
            m120.Revenue = 1004558444;
            m120.Runtime = 152;
            m120.Tagline = "Why So Serious?";
            m120.MPAARating = enumMPAARating.PG13;
            m120.Actors = "Christian Bale, Heath Ledger, Aaron Eckhart, Michael Caine, Maggie Gyllenhaal, Gary Oldman";
            db.Movies.AddOrUpdate(m => m.Title, m120);
            db.SaveChanges();


            m120 = db.Movies.FirstOrDefault(m => m.MovieNum == m120.MovieNum);
            m120.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m120.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m120.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Crime"));
            m120.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Thriller"));
            db.SaveChanges();


            Movie m121 = new Movie();
            m121.MovieNum = 3122;
            m121.Title = "Star Trek";
            m121.Overview = "The fate of the galaxy rests in the hands of bitter rivals. One, James Kirk, is a delinquent, thrill-seeking Iowa farm boy. The other, Spock, a Vulcan, was raised in a logic-based society that rejects all emotion. As fiery instinct clashes with calm reason, their unlikely but powerful partnership is the only thing capable of leading their crew through unimaginable danger, boldly going where no one has gone before. The human adventure has begun again.";
            m121.ReleaseDate = new DateTime(2009, 5, 6);
            m121.Revenue = 385680446;
            m121.Runtime = 127;
            m121.Tagline = "The future begins.";
            m121.MPAARating = enumMPAARating.PG13;
            m121.Actors = "Chris Pine, Zachary Quinto, Leonard Nimoy, Eric Bana, Bruce Greenwood, Karl Urban";
            db.Movies.AddOrUpdate(m => m.Title, m121);
            db.SaveChanges();


            m121 = db.Movies.FirstOrDefault(m => m.MovieNum == m121.MovieNum);
            m121.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m121.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m121.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            db.SaveChanges();


            Movie m122 = new Movie();
            m122.MovieNum = 3123;
            m122.Title = "Up";
            m122.Overview = "Carl Fredricksen spent his entire life dreaming of exploring the globe and experiencing life to its fullest. But at age 78, life seems to have passed him by, until a twist of fate (and a persistent 8-year old Wilderness Explorer named Russell) gives him a new lease on life.";
            m122.ReleaseDate = new DateTime(2009, 5, 13);
            m122.Revenue = 735099082;
            m122.Runtime = 96;
            m122.Tagline = "Fly Up to Venezuela";
            m122.MPAARating = enumMPAARating.PG;
            m122.Actors = "Ed Asner, Christopher Plummer, Jordan Nagai, Bob Peterson, Delroy Lindo, Jerome Ranft";
            db.Movies.AddOrUpdate(m => m.Title, m122);
            db.SaveChanges();


            m122 = db.Movies.FirstOrDefault(m => m.MovieNum == m122.MovieNum);
            m122.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m122.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m122.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m122.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            db.SaveChanges();


            Movie m123 = new Movie();
            m123.MovieNum = 3124;
            m123.Title = "Harry Potter and the Half-Blood Prince";
            m123.Overview = "As Harry begins his sixth year at Hogwarts, he discovers an old book marked as 'Property of the Half-Blood Prince', and begins to learn more about Lord Voldemort's dark past.";
            m123.ReleaseDate = new DateTime(2009, 7, 7);
            m123.Revenue = 933959197;
            m123.Runtime = 153;
            m123.Tagline = "Dark Secrets Revealed";
            m123.MPAARating = enumMPAARating.PG;
            m123.Actors = "Daniel Radcliffe, Rupert Grint, Emma Watson, Tom Felton, Michael Gambon, Jim Broadbent";
            db.Movies.AddOrUpdate(m => m.Title, m123);
            db.SaveChanges();


            m123 = db.Movies.FirstOrDefault(m => m.MovieNum == m123.MovieNum);
            m123.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m123.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m123.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            db.SaveChanges();


            Movie m124 = new Movie();
            m124.MovieNum = 3125;
            m124.Title = "The Princess and the Frog";
            m124.Overview = "A waitress, desperate to fulfill her dreams as a restaurant owner, is set on a journey to turn a frog prince back into a human being, but she has to do face the same problem after she kisses him.";
            m124.ReleaseDate = new DateTime(2009, 12, 8);
            m124.Revenue = 267045765;
            m124.Runtime = 97;
            m124.Tagline = "Every Love Story Begins With a Kiss...";
            m124.MPAARating = enumMPAARating.G;
            m124.Actors = "Anika Noni Rose, Bruno Campos, Keith David, Michael-Leon Wooley, Jennifer Cody, Jim Cummings";
            db.Movies.AddOrUpdate(m => m.Title, m124);
            db.SaveChanges();


            m124 = db.Movies.FirstOrDefault(m => m.MovieNum == m124.MovieNum);
            m124.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            m124.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m124.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m124.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            db.SaveChanges();


            Movie m125 = new Movie();
            m125.MovieNum = 3126;
            m125.Title = "Avatar";
            m125.Overview = "In the 22nd century, a paraplegic Marine is dispatched to the moon Pandora on a unique mission, but becomes torn between following orders and protecting an alien civilization.";
            m125.ReleaseDate = new DateTime(2009, 12, 10);
            m125.Revenue = 2787965087;
            m125.Runtime = 162;
            m125.Tagline = "Enter the World of Pandora.";
            m125.MPAARating = enumMPAARating.PG13;
            m125.Actors = "Sam Worthington, Zoe Saldana, Sigourney Weaver, Stephen Lang, Michelle Rodriguez, Giovanni Ribisi";
            db.Movies.AddOrUpdate(m => m.Title, m125);
            db.SaveChanges();


            m125 = db.Movies.FirstOrDefault(m => m.MovieNum == m125.MovieNum);
            m125.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m125.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m125.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            m125.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            db.SaveChanges();


            Movie m126 = new Movie();
            m126.MovieNum = 3127;
            m126.Title = "Toy Story 3";
            m126.Overview = "Woody, Buzz, and the rest of Andy's toys haven't been played with in years. With Andy about to go to college, the gang find themselves accidentally left at a nefarious day care center. The toys must band together to escape and return home to Andy.";
            m126.ReleaseDate = new DateTime(2010, 6, 16);
            m126.Revenue = 1066969703;
            m126.Runtime = 103;
            m126.Tagline = "No toy gets left behind.";
            m126.MPAARating = enumMPAARating.G;
            m126.Actors = "Tom Hanks, Tim Allen, Ned Beatty, Joan Cusack, Michael Keaton, Whoopi Goldberg";
            db.Movies.AddOrUpdate(m => m.Title, m126);
            db.SaveChanges();


            m126 = db.Movies.FirstOrDefault(m => m.MovieNum == m126.MovieNum);
            m126.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m126.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m126.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


            Movie m127 = new Movie();
            m127.MovieNum = 3128;
            m127.Title = "The King's Speech";
            m127.Overview = "The King's Speech tells the story of the man who became King George VI, the father of Queen Elizabeth II. After his brother abdicates, George ('Bertie') reluctantly assumes the throne. Plagued by a dreaded stutter and considered unfit to be king, Bertie engages the help of an unorthodox speech therapist named Lionel Logue. Through a set of unexpected techniques, and as a result of an unlikely friendship, Bertie is able to find his voice and boldly lead the country into war.";
            m127.ReleaseDate = new DateTime(2010, 9, 6);
            m127.Revenue = 414211549;
            m127.Runtime = 118;
            m127.Tagline = "Find your voice.";
            m127.MPAARating = enumMPAARating.R;
            m127.Actors = "Colin Firth, Geoffrey Rush, Helena Bonham Carter, Guy Pearce, Timothy Spall, Michael Gambon";
            db.Movies.AddOrUpdate(m => m.Title, m127);
            db.SaveChanges();


            m127 = db.Movies.FirstOrDefault(m => m.MovieNum == m127.MovieNum);
            m127.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            m127.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "History"));
            db.SaveChanges();


            Movie m128 = new Movie();
            m128.MovieNum = 3129;
            m128.Title = "Moneyball";
            m128.Overview = "The story of Oakland Athletics general manager Billy Beane's successful attempt to put together a baseball team on a budget, by employing computer-generated analysis to draft his players.";
            m128.ReleaseDate = new DateTime(2011, 9, 22);
            m128.Revenue = 110206216;
            m128.Runtime = 133;
            m128.Tagline = "What are you really worth?";
            m128.MPAARating = enumMPAARating.PG13;
            m128.Actors = "Brad Pitt, Jonah Hill, Philip Seymour Hoffman, Robin Wright, Chris Pratt, Stephen Bishop";
            db.Movies.AddOrUpdate(m => m.Title, m128);
            db.SaveChanges();


            m128 = db.Movies.FirstOrDefault(m => m.MovieNum == m128.MovieNum);
            m128.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Drama"));
            db.SaveChanges();


            Movie m129 = new Movie();
            m129.MovieNum = 3130;
            m129.Title = "Brave";
            m129.Overview = "Brave is set in the mystical Scottish Highlands, where M??rida is the princess of a kingdom ruled by King Fergus and Queen Elinor. An unruly daughter and an accomplished archer, M??rida one day defies a sacred custom of the land and inadvertently brings turmoil to the kingdom. In an attempt to set things right, M??rida seeks out an eccentric old Wise Woman and is granted an ill-fated wish. Also figuring into M??rida???s quest ???? and serving as comic relief ???? are the kingdom???s three lords: the enormous Lord MacGuffin, the surly Lord Macintosh, and the disagreeable Lord Dingwall.";
            m129.ReleaseDate = new DateTime(2012, 6, 21);
            m129.Revenue = 538983207;
            m129.Runtime = 93;
            m129.Tagline = "Change your fate.";
            m129.MPAARating = enumMPAARating.PG;
            m129.Actors = "Kelly Macdonald, Julie Walters, Billy Connolly, Emma Thompson, Kevin McKidd, Craig Ferguson";
            db.Movies.AddOrUpdate(m => m.Title, m129);
            db.SaveChanges();


            m129 = db.Movies.FirstOrDefault(m => m.MovieNum == m129.MovieNum);
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m129.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m130 = new Movie();
            m130.MovieNum = 3131;
            m130.Title = "Pitch Perfect";
            m130.Overview = "College student Beca knows she does not want to be part of a clique, but that's exactly where she finds herself after arriving at her new school. Thrust in among mean gals, nice gals and just plain weird gals, Beca finds that the only thing they have in common is how well they sing together. She takes the women of the group out of their comfort zone of traditional arrangements and into a world of amazing harmonic combinations in a fight to the top of college music competitions.";
            m130.ReleaseDate = new DateTime(2012, 9, 28);
            m130.Revenue = 115350426;
            m130.Runtime = 112;
            m130.Tagline = "Get pitch slapped.";
            m130.MPAARating = enumMPAARating.PG13;
            m130.Actors = "Anna Kendrick, Skylar Astin, Brittany Snow, Anna Camp, Rebel Wilson, Ben Platt";
            db.Movies.AddOrUpdate(m => m.Title, m130);
            db.SaveChanges();


            m130 = db.Movies.FirstOrDefault(m => m.MovieNum == m130.MovieNum);
            m130.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m130.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Musical"));
            m130.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Romance"));
            db.SaveChanges();


            Movie m131 = new Movie();
            m131.MovieNum = 3132;
            m131.Title = "The Lego Movie";
            m131.Overview = "An ordinary Lego mini-figure, mistakenly thought to be the extraordinary MasterBuilder, is recruited to join a quest to stop an evil Lego tyrant from gluing the universe together.";
            m131.ReleaseDate = new DateTime(2014, 2, 6);
            m131.Revenue = 469160692;
            m131.Runtime = 100;
            m131.Tagline = "The story of a nobody who saved everybody.";
            m131.MPAARating = enumMPAARating.PG;
            m131.Actors = "Chris Pratt, Will Ferrell, Elizabeth Banks, Will Arnett, Nick Offerman, Alison Brie";
            db.Movies.AddOrUpdate(m => m.Title, m131);
            db.SaveChanges();


            m131 = db.Movies.FirstOrDefault(m => m.MovieNum == m131.MovieNum);
            m131.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            m131.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Animation"));
            m131.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            m131.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Family"));
            m131.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Fantasy"));
            db.SaveChanges();


            Movie m132 = new Movie();
            m132.MovieNum = 3133;
            m132.Title = "Guardians of the Galaxy";
            m132.Overview = "Light years from Earth, 26 years after being abducted, Peter Quill finds himself the prime target of a manhunt after discovering an orb wanted by Ronan the Accuser.";
            m132.ReleaseDate = new DateTime(2014, 7, 30);
            m132.Revenue = 773328629;
            m132.Runtime = 121;
            m132.Tagline = "All heroes start somewhere.";
            m132.MPAARating = enumMPAARating.PG13;
            m132.Actors = "Chris Pratt, Zoe Saldana, Dave Bautista, Vin Diesel, Bradley Cooper, Lee Pace";
            db.Movies.AddOrUpdate(m => m.Title, m132);
            db.SaveChanges();


            m132 = db.Movies.FirstOrDefault(m => m.MovieNum == m132.MovieNum);
            m132.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Action"));
            m132.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Science Fiction"));
            m132.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Adventure"));
            db.SaveChanges();


            Movie m133 = new Movie();
            m133.MovieNum = 3134;
            m133.Title = "Bad Moms";
            m133.Overview = "When three overworked and under-appreciated moms are pushed beyond their limits, they ditch their conventional responsibilities for a jolt of long overdue freedom, fun, and comedic self-indulgence.";
            m133.ReleaseDate = new DateTime(2016, 7, 28);
            m133.Revenue = 183936074;
            m133.Runtime = 100;
            m133.Tagline = "Party like a mother.";
            m133.MPAARating = enumMPAARating.R;
            m133.Actors = "Mila Kunis, Kristen Bell, Kathryn Hahn, Christina Applegate, Jada Pinkett Smith, Annie Mumolo";
            db.Movies.AddOrUpdate(m => m.Title, m133);
            db.SaveChanges();


            m133 = db.Movies.FirstOrDefault(m => m.MovieNum == m133.MovieNum);
            m133.Genres.Add(db.Genres.FirstOrDefault(g => g.Name == "Comedy"));
            db.SaveChanges();


        }
    }
}