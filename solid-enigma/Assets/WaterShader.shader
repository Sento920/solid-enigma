Shader "Custom/NewWaterShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void vert(inout appdata_full v) {
			float3 vertexWorld = mul(unity_ObjectToWorld, v.vertex).xyz;

			// x waves
			float wx = 0;
			wx += sin((vertexWorld.x * _Time * 0.026) + 22.147);
			wx += sin((vertexWorld.x * _Time * 0.023) + 34.523);
			wx += sin((vertexWorld.x * _Time * 0.017) + 53.344);
			wx += sin((vertexWorld.x * _Time * 0.012) + 23.153);
			wx /= 4;

			// z waves
			float wz = 0;
			wz += sin((vertexWorld.z * _Time * 0.024) + 5.623);
			wz += sin((vertexWorld.z * _Time * 0.028) + 26.726);
			wz += sin((vertexWorld.z * _Time * 0.013) + 34.592);
			wz += sin((vertexWorld.z * _Time * 0.015) + 266.217);
			wz /= 4;

			v.vertex.y += (wx + wz) * 2;


		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
