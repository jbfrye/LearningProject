using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.3
    class JukeBox
    {
        public JukeBox()
        { }

        public static void RunJukeBox()
        {
            
        }
    }

    class CD
    {
        System.Collections.Generic.List<Song> tracks;
        int currentSong = 0;

        public CD(System.Collections.Generic.List<Song> t)
        {
            tracks = t;
        }

        public Song PlayNextSong()
        {
            if (tracks.Count == 0)
                return null;
            Song playing = tracks[currentSong];
            if (tracks.Count <= currentSong + 1)
                currentSong = 0;
            else
                currentSong++;

            return playing;
        }
    }

    class Playlist
    {
        System.Collections.Generic.List<Song> playList;
        int currentSong = 0;

        public Playlist()
        {
            playList = new System.Collections.Generic.List<Song>();
        }

        public void AddSong(Song s)
        {
            playList.Add(s);
        }

        public Song PlayNextSong()
        {
            if (playList.Count == 0)
                return null;
            Song playing = playList[currentSong];
            if (playList.Count <= currentSong + 1)
                currentSong = 0;
            else
                currentSong++;

            return playing;
        }
    }

    class Song
    {
        public string name;
        public Artist artist;

        public Song(string n, Artist art)
        {
            name = n;
            artist = art;
        }
    }

    class Artist
    {
        public string name;
        
        public Artist(string n)
        {
            name = n;
        }
    }
}
