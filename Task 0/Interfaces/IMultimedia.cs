namespace Task_0.Interfaces
{
    public interface IMultimedia
    {
        Multimedia GetMultimediaFromDirectory(string path);
        void AddMediaFile(MediaFile mediaFile);
        void RemoveMediaFile(MediaFile mediaFile);
        void AddPlayList(Playlist playlist);
        void RemovePlayList(Playlist playlist);
        MediaFile FindMediaFile(string name);
        string ToString();
    }
}