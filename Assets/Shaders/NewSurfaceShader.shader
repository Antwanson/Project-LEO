Shader "Custom/myAdditive" 
{
    Properties {
        _MainTex ("Particle Texture", 2D) = "white" {}
    }

    Category {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }
        
        BindChannels {
            Bind "Color", color
            Bind "Vertex", vertex
            Bind "TexCoord", texcoord
        }
        
        SubShader {
            Pass {
                Stencil 
                {
                    Ref 1
                    Comp NotEqual
                    Pass Replace
                }
                SetTexture [_MainTex] {
                    combine texture * primary
                }
            }
            Pass {
                Stencil {
                    Ref 1
                    Comp Equal
                }
                Blend SrcAlpha One
                SetTexture [_MainTex] {
                    combine texture * primary
                }
            }
        }
    }
}