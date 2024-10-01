package xamarin.google.android.play.core.assetpacks;

import com.google.android.play.core.assetpacks.AssetPackState;
import com.google.android.play.core.assetpacks.AssetPackStateUpdateListener;

public class AssetPackStateUpdateListenerWrapper {
    private AssetPackStateUpdateListener assetPackStateUpdatedListener = state -> {
        onStateUpdate (state);
    };

    void onStateUpdate(AssetPackState state)
    {
        if (stateUpdateListener != null)
            stateUpdateListener.OnStateUpdate(state);
    }

    public AssetPackStateUpdateListener GetListener()
    {
        return assetPackStateUpdatedListener;
    }

    public interface AssetPackStateListener {
        /**
         * Called when an the State is Updated
         *
         * @param state The Install Session State.
         */
        abstract void OnStateUpdate (AssetPackState state);
    }

    private AssetPackStateListener stateUpdateListener = null;

    public void setStateUpdateListener (AssetPackStateListener listener)
    {
        stateUpdateListener = listener;
    }
}
