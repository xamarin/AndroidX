using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Health.Services.Client.Data {
	public sealed partial class DebouncedDataTypeCondition : global::Java.Lang.Object {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.health.services.client.data']/class[@name='DebouncedDataTypeCondition']/method[@name='createDebouncedDataTypeCondition' and count(parameter)=5 and parameter[1][@type='D'] and parameter[2][@type='T'] and parameter[3][@type='androidx.health.services.client.data.ComparisonType'] and parameter[4][@type='int'] and parameter[5][@type='int']]"
		[Register ("createDebouncedDataTypeCondition", "(Landroidx/health/services/client/data/DataType;Ljava/lang/Number;Landroidx/health/services/client/data/ComparisonType;II)Landroidx/health/services/client/data/DebouncedDataTypeCondition;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] { "T extends java.lang.Number", "D extends androidx.health.services.client.data.AggregateDataType<T, ? extends androidx.health.services.client.data.StatisticalDataPoint<T>>" })]
		public static unsafe global::AndroidX.Health.Services.Client.Data.DebouncedDataTypeCondition CreateDebouncedDataTypeConditionForAggregateDataType (global::Java.Lang.Object dataType, global::Java.Lang.Object threshold, global::AndroidX.Health.Services.Client.Data.ComparisonType comparisonType, int initialDelaySeconds, int durationAtThresholdSeconds)
		{
			const string __id = "createDebouncedDataTypeCondition.(Landroidx/health/services/client/data/DataType;Ljava/lang/Number;Landroidx/health/services/client/data/ComparisonType;II)Landroidx/health/services/client/data/DebouncedDataTypeCondition;";
			IntPtr native_dataType = JNIEnv.ToLocalJniHandle (dataType);
			IntPtr native_threshold = JNIEnv.ToLocalJniHandle (threshold);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [5];
				__args [0] = new JniArgumentValue (native_dataType);
				__args [1] = new JniArgumentValue (native_threshold);
				__args [2] = new JniArgumentValue ((comparisonType == null) ? IntPtr.Zero : ((global::Java.Lang.Object) comparisonType).Handle);
				__args [3] = new JniArgumentValue (initialDelaySeconds);
				__args [4] = new JniArgumentValue (durationAtThresholdSeconds);
				var __rm = _members.StaticMethods.InvokeObjectMethod (__id, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Health.Services.Client.Data.DebouncedDataTypeCondition> (__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
			} finally {
				JNIEnv.DeleteLocalRef (native_dataType);
				JNIEnv.DeleteLocalRef (native_threshold);
				global::System.GC.KeepAlive (dataType);
				global::System.GC.KeepAlive (threshold);
				global::System.GC.KeepAlive (comparisonType);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.health.services.client.data']/class[@name='DebouncedDataTypeCondition']/method[@name='createDebouncedDataTypeCondition' and count(parameter)=5 and parameter[1][@type='D'] and parameter[2][@type='T'] and parameter[3][@type='androidx.health.services.client.data.ComparisonType'] and parameter[4][@type='int'] and parameter[5][@type='int']]"
		[Register ("createDebouncedDataTypeCondition", "(Landroidx/health/services/client/data/DataType;Ljava/lang/Number;Landroidx/health/services/client/data/ComparisonType;II)Landroidx/health/services/client/data/DebouncedDataTypeCondition;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] { "T extends java.lang.Number", "D extends androidx.health.services.client.data.DeltaDataType<T, ? extends androidx.health.services.client.data.SampleDataPoint<T>>" })]
		public static unsafe global::AndroidX.Health.Services.Client.Data.DebouncedDataTypeCondition CreateDebouncedDataTypeConditionForDeltaDataType (global::Java.Lang.Object dataType, global::Java.Lang.Object threshold, global::AndroidX.Health.Services.Client.Data.ComparisonType comparisonType, int initialDelaySeconds, int durationAtThresholdSeconds)
		{
			const string __id = "createDebouncedDataTypeCondition.(Landroidx/health/services/client/data/DataType;Ljava/lang/Number;Landroidx/health/services/client/data/ComparisonType;II)Landroidx/health/services/client/data/DebouncedDataTypeCondition;";
			IntPtr native_dataType = JNIEnv.ToLocalJniHandle (dataType);
			IntPtr native_threshold = JNIEnv.ToLocalJniHandle (threshold);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [5];
				__args [0] = new JniArgumentValue (native_dataType);
				__args [1] = new JniArgumentValue (native_threshold);
				__args [2] = new JniArgumentValue ((comparisonType == null) ? IntPtr.Zero : ((global::Java.Lang.Object) comparisonType).Handle);
				__args [3] = new JniArgumentValue (initialDelaySeconds);
				__args [4] = new JniArgumentValue (durationAtThresholdSeconds);
				var __rm = _members.StaticMethods.InvokeObjectMethod (__id, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Health.Services.Client.Data.DebouncedDataTypeCondition> (__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
			} finally {
				JNIEnv.DeleteLocalRef (native_dataType);
				JNIEnv.DeleteLocalRef (native_threshold);
				global::System.GC.KeepAlive (dataType);
				global::System.GC.KeepAlive (threshold);
				global::System.GC.KeepAlive (comparisonType);
			}
		}
	}
}
