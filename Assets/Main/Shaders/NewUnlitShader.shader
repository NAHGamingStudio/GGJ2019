Shader "Unlit/NewUnlitShader"
{
	Properties
	{
		_Color("Tint Color", Color) = (1,1,1,1)
	}

		SubShader
	{
		Tags{ "Queue" = "Transparent" }

		Pass
	{
		ZWrite On
		ColorMask 0
	}
		
		Blend OneMinusDstColor OneMinusSrcAlpha //invert blending, so long as FG color is 1,1,1,1
		BlendOp Add

		Pass
	{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag 
		#pragma target 2.0


		uniform float4 _Color;

	struct vertexInput
	{
		float4 vertex: POSITION;
		float4 color : COLOR;
	};

	struct fragmentInput
	{
		float4 pos : SV_POSITION;
		float4 color : COLOR0;
	};

	fragmentInput vert(vertexInput i)
	{
		fragmentInput o;
		o.pos = UnityObjectToClipPos(i.vertex);
		o.color = _Color;
		return o;
	}

	half4 frag(fragmentInput i) : COLOR
	{
		float3 color = i.color.rgb;
		float grayscale = dot(color, float3(0.2126, 0.7152, 0.0722));
		return float4(grayscale, grayscale, grayscale, 1.0);
	}

		ENDCG
	}
	}
}
