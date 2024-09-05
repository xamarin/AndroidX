using System.Runtime.CompilerServices;

/*
Adding TypeForwardedTo introduces cyclic dependency between Xamarin.Grpc.Core and Xamarin.Grpc.Core.Util

[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.AdvancedTlsX509KeyManager))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.AdvancedTlsX509TrustManager))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.CertificateUtils))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.ForwardingClientStreamTracer))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.ForwardingLoadBalancer))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.ForwardingLoadBalancerHelper))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.ForwardingSubchannel))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.GracefulSwitchLoadBalancer))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.MutableHandlerRegistry))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.OutlierDetectionLoadBalancer))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.OutlierDetectionLoadBalancerProvider))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.RoundRobinLoadBalancer))]
[assembly: TypeForwardedTo (typeof (Xamarin.Grpc.Core.Util.TransmitStatusRuntimeExceptionInterceptor))]
*/