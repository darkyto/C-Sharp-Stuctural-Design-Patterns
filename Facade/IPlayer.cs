namespace Facade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPlayer
    {
        void Play();

        void Stop();

        void Load(MediaEntity media);
    }
}
