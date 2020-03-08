﻿Shader "Custom/OutlineShader" {

	Properties{
		_MainTex("Texture", 2D) = "what" {}
		_Color("Colour", Color) = (1, 1, 1, 1)
	}

	SubShader{

			Tags{
					"Queue" = "Transparent"
				}

		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass{

		CGPROGRAM

		#pragma vertex vertexFunc
		#pragma fragment fragmentFunc
		#include "UnityCG.cginc"

		sampler2D _MainTex;

		struct v2f {
		float4 pos : SV_POSITION;
		half2 uv : TEXCORD0;
		};

		v2f vertexFunc(appdata_base v) {
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.uv = v.texcoord;

			return o;
		}

		fixed4 _Color;
		float4 _MainTex_TexelSize;

			fixed4 fragmentFunc(v2f i) : COLOR{
				half4 c = tex2D(_MainTex, i.uv);
				c.rgb *= c.a;
				half4 outlineC = _Color;
				outlineC.a *= ceil(c.a);
				outlineC.rgb *= c.a;

				fixed upAlpha = tex2D(_MainTex, i.uv + 3 * fixed2(0, _MainTex_TexelSize.y)).a;
				fixed downAlpha = tex2D(_MainTex, i.uv - 3 * fixed2(0, _MainTex_TexelSize.y)).a;
				fixed rightAlpha = tex2D(_MainTex, i.uv + 3 * fixed2(_MainTex_TexelSize.x, 0)).a;
				fixed leftAlpha = tex2D(_MainTex, i.uv - 3 * fixed2(_MainTex_TexelSize.y, 0)).a;

				return lerp(outlineC, c, ceil(upAlpha * downAlpha * rightAlpha * leftAlpha));
		}

		ENDCG
		}
	}

}