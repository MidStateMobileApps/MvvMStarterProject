package md506b5c5e8c12bcc37b65132f8500124ec;


public class MainMenuView
	extends md5db6e064a20cf6ac5f59d10f23f225a01.MvxActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("NewProjectTemplate.Droid.Resources.Views.MainMenuView, NewProjectTemplate.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainMenuView.class, __md_methods);
	}


	public MainMenuView ()
	{
		super ();
		if (getClass () == MainMenuView.class)
			mono.android.TypeManager.Activate ("NewProjectTemplate.Droid.Resources.Views.MainMenuView, NewProjectTemplate.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
