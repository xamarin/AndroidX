The V4 Android Support Library is commonly used in applications due to it supporting many of the basic elements used within other libraries and applications.

App Components
 - Fragment - Adds support for encapsulation of user interface and functionality with Fragments, enabling applications to provide layouts that adjust between small and large-screen devices.
 - NotificationCompat - Adds support for rich notification features.
 - LocalBroadcastManager - Allows applications to easily register for and receive intents within a single application without broadcasting them globally. 

User Interface
 - ViewPager - Adds a ViewGroup that manages the layout for the child views, which the user can swipe between.
 - PagerTitleStrip - Adds a non-interactive title strip, that can be added as a child of ViewPager.
 - PagerTabStrip - Adds a navigation widget for switching between paged views, that can also be used with ViewPager.
 - DrawerLayout - Adds support for creating a Navigation Drawer that can be pulled in from the edge of a window.
 - SlidingPaneLayout - Adds widget for creating linked summary and detail views that appropriately adapt to various screen sizes.
Accessibility
 - ExploreByTouchHelper - Adds a helper class for implementing accessibility support for custom views.
 - AccessibilityEventCompat - Adds support for AccessibilityEvent. For more information about implementing accessibility, see Accessibility.
 - AccessibilityNodeInfoCompat - Adds support for AccessibilityNodeInfo.
 - AccessibilityNodeProviderCompat - Adds support for AccessibilityNodeProvider.
 - AccessibilityDelegateCompat - Adds support for View.AccessibilityDelegate.

Content
 - Loader - Adds support for asynchronous loading of data. The library also provides concrete implementations of this class, including CursorLoader and AsyncTaskLoader.
 - FileProvider - Adds support for sharing of private files between applications.