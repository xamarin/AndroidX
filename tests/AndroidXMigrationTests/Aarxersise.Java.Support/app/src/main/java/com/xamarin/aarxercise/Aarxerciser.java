package com.xamarin.aarxercise;

import android.content.Context;
import android.widget.TextView;
import android.support.v4.app.Fragment;

public class Aarxerciser {

    public Fragment CreateFragment(Context context)
    {
        SimpleFragment fragment = new SimpleFragment();
        return fragment;
    }

    public SimpleFragment CreateSimpleFragment(Context context)
    {
        SimpleFragment fragment = new SimpleFragment();
        return fragment;
    }

    public void UpdateSimpleFragment(SimpleFragment fragment, String text)
    {
        ((TextView)fragment.getView().findViewById(R.id.simpleFragmentTextView)).setText(text);
    }

    public void UpdateFragment(Fragment fragment, String text)
    {
        ((TextView)fragment.getView().findViewById(R.id.simpleFragmentTextView)).setText(text);
    }
}
