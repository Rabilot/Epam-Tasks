using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Task_0
{
    public class Multimedia
    {
        public List<Music> MusicList = new List<Music>();
        public List<Photo> PhotoList = new List<Photo>();
        public List<VideoFile> VideoList = new List<VideoFile>();
        
        
        
        public Multimedia GetMultimediaFromFile(string path)
        {
            Multimedia multimedia = new Multimedia();
            string[] fileStrings;
            fileStrings = File.ReadAllLines(path);
            foreach (var str in fileStrings)
            {
                AddMultimedia(GetMultimediaFromString(str));
            }

            return multimedia;
        }

        public void AddMultimedia(Multimedia multimedia)
        {
            foreach (var Video in multimedia.VideoList)
            {
                VideoList.Add(Video);
            }
            foreach (var music in multimedia.MusicList)
            {
                MusicList.Add(music);
            }
            foreach (var photo in multimedia.PhotoList)
            {
                PhotoList.Add(photo);
            }
        }

        public Multimedia GetMultimediaFromString(string s)
        {
            Multimedia multimedia = new Multimedia();
            string[] infoFromLine = new string[s.Split(' ').Length];
                int i = 0;
                foreach (var c in s)
                {
                    
                    if (c != ' ')
                    {
                        infoFromLine[i] += c;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (infoFromLine[0] == "Video")
                {
                    multimedia.VideoList.Add(new VideoFile().getInfoByVideo(infoFromLine));
                }
                else if (infoFromLine[0] == "Photo")
                {
                    multimedia.PhotoList.Add(new Photo().getInfoByPhoto(infoFromLine));
                }
                else if (infoFromLine[0] == "Music")
                {
                    multimedia.MusicList.Add(new Music().getInfoByMusic(infoFromLine));
                }
                return multimedia;
        }

        public void SafeByType()
        {
            StreamWriter swVideo = new StreamWriter(Directory.GetCurrentDirectory() + "\\video.txt");
            swVideo.Write(GetVideoListByText());
            swVideo.Close();
            StreamWriter swPhoto = new StreamWriter(Directory.GetCurrentDirectory() + "\\photo.txt");
            swPhoto.Write(GetPhotoListByText());
            swPhoto.Close();
            StreamWriter swMusic = new StreamWriter(Directory.GetCurrentDirectory() + "\\music.txt");
            swMusic.Write(GetMusicListByText());
            swMusic.Close();
        }

        private string GetVideoListByText()
        {
            string result = "";
            for (int i = 0; i < VideoList.Count ; i++)
            {
                result += VideoList[i];
                if (i != VideoList.Count - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }
        
        private string GetPhotoListByText()
        {
            string result = "";
            for (int i = 0; i < PhotoList.Count; i++)
            {
                result += PhotoList[i];
                if (i != PhotoList.Count - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }
        
        private string GetMusicListByText()
        {
            string result = "";
            for (int i = 0; i < MusicList.Count; i++)
            {
                result += MusicList[i];
                if (i != MusicList.Count - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }

        public void Serialize()
        {
            Multimedia multimedia = new Multimedia();
            multimedia.MusicList = MusicList;
            multimedia.PhotoList = PhotoList;
            multimedia.VideoList = VideoList;
            XmlSerializer formatter = new XmlSerializer(typeof(Multimedia));
            FileStream fs = new FileStream("Output.xml", FileMode.OpenOrCreate);
            formatter.Serialize(fs, multimedia);
            fs.Close();
        }

        public void Deserialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Multimedia));
            FileStream fs = new FileStream("Output.xml", FileMode.OpenOrCreate);
            Multimedia multimedia = (Multimedia) formatter.Deserialize(fs);
            MusicList = multimedia.MusicList;
            PhotoList = multimedia.PhotoList;
            VideoList = multimedia.VideoList;
            fs.Close();
        }

        public void AddMultimediaFromXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Multimedia));
            FileStream fs = new FileStream("Output.xml", FileMode.OpenOrCreate);
            Multimedia multimedia = (Multimedia) formatter.Deserialize(fs);
            fs.Close();
            AddMultimedia(multimedia);
        }
        

    }
}