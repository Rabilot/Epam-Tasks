namespace Task_0.Interfaces
{
    public interface IPlaylist
    {
        void AddMediaFile(MediaFile mediaFile);
        void RemoveMediaFile(MediaFile mediaFile);
        void Play();
    }
}