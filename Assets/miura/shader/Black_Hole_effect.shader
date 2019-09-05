Shader "Custom/Black_Hole_effect"
{


	SubShader{
		 Cull Off

		 Tags { "RenderType" = "Transparent" }
		 LOD 200

		 CGPROGRAM
		 #pragma surface surf Standard alpha:fade
		 #pragma target 3.0

		 

		 struct Input {
			 float3 worldPos;
		 };
		 
		 float4 _ObjectPosition;
		
		 void surf(Input IN, inout SurfaceOutputStandard o) {
			 float dist = distance(_ObjectPosition, IN.worldPos);
			 float val = abs(sin(dist * 3.0 + _Time * 50));


			 if (val > 0.99) {
				 o.Albedo = fixed4(0.7, 0, 0.7, 1);
				 o.Alpha = 0.5;
			 }
			 else {
				 o.Albedo = fixed4(1, 1, 1, 1);
				 o.Alpha = 0.0;
			 }
		 }

		 ENDCG
	}
		FallBack "Diffuse"
}
