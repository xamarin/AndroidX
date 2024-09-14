package xamarin.google.android.play.core.splitinstall;

import com.google.android.play.core.splitinstall.SplitInstallManager;
import com.google.android.play.core.splitinstall.SplitInstallManagerFactory;
import com.google.android.play.core.splitinstall.SplitInstallRequest;
import com.google.android.play.core.splitinstall.SplitInstallSessionState;
import com.google.android.play.core.splitinstall.SplitInstallStateUpdatedListener;

public class SplitInstallStateUpdatedListenerWrapper {
    private SplitInstallStateUpdatedListener splitInstallStateUpdatedListener = state -> {
        onStateUpdate (state);
    };

    void onStateUpdate(SplitInstallSessionState state)
    {
        if (stateUpdateListener != null)
            stateUpdateListener.OnStateUpdate(state);
    }

    public SplitInstallStateUpdatedListener GetListener()
    {
        return splitInstallStateUpdatedListener;
    }

    public interface StateUpdateListener {
        /**
         * Called when an the State is Updated
         *
         * @param state The Install Session State.
         */
        abstract void OnStateUpdate (SplitInstallSessionState state);
    }

    private StateUpdateListener stateUpdateListener = null;

    public void setStateUpdateListener (StateUpdateListener listener)
    {
        stateUpdateListener = listener;
    }
}
