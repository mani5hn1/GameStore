package crc640649f61fae078ff4;


public class CartViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GameStore.ViewHolders.CartViewHolder, GameStore", CartViewHolder.class, __md_methods);
	}


	public CartViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CartViewHolder.class)
			mono.android.TypeManager.Activate ("GameStore.ViewHolders.CartViewHolder, GameStore", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
