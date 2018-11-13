namespace ppedv.Zeus.Model
{
    public interface I3dDrucker
    {
        void Start(string gcode);
        void Stop();
        void Pause();
        void Resume();
        DruckerStatus Status { get; }
    }
}