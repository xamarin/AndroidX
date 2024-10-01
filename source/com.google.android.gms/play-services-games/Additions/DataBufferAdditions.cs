using System;
using System.Linq;
using System.Collections.Generic;
using Java.Util;

namespace Android.Gms.Games
{
    public partial class GameBuffer : IEnumerable<IGame>
    {
        public IEnumerator<IGame> GetEnumerator()
        {
            return this.ToEnumerable<IGame> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class PlayerBuffer : IEnumerable<IPlayer>
    {
        public IEnumerator<IPlayer> GetEnumerator()
        {
            return this.ToEnumerable<IPlayer> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
    
namespace Android.Gms.Games.Achievement
{
    public partial class AchievementBuffer : IEnumerable<IAchievement>
    {
        public IEnumerator<IAchievement> GetEnumerator()
        {
            return this.ToEnumerable<IAchievement> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

namespace Android.Gms.Games.Event
{
    public partial class EventBuffer : IEnumerable<IEvent>
    {
        public IEnumerator<IEvent> GetEnumerator()
        {
            return this.ToEnumerable<IEvent> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

namespace Android.Gms.Games.LeaderBoard
{
    public partial class LeaderboardBuffer : IEnumerable<ILeaderboard>
    {
        public IEnumerator<ILeaderboard> GetEnumerator()
        {
            return this.ToEnumerable<ILeaderboard> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class LeaderboardScoreBuffer : IEnumerable<ILeaderboardScore>
    {
        public IEnumerator<ILeaderboardScore> GetEnumerator()
        {
            return this.ToEnumerable<ILeaderboardScore> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

namespace Android.Gms.Games.Snapshot
{
    public partial class SnapshotMetadataBuffer : IEnumerable<ISnapshotMetadata>
    {
        public IEnumerator<ISnapshotMetadata> GetEnumerator()
        {
            return this.ToEnumerable<ISnapshotMetadata> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

namespace Android.Gms.Games.Stats
{
    public partial class PlayerStatsBuffer : IEnumerable<IPlayerStats>
    {
        public IEnumerator<IPlayerStats> GetEnumerator()
        {
            return this.ToEnumerable<IPlayerStats> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
