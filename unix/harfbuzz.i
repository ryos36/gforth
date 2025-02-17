// this file is in the public domain
%module harfbuzz
%insert("include")
%{
#include <harfbuzz/hb.h>
#include <harfbuzz/hb-ft.h>
#ifdef __gnu_linux__
#undef stderr
extern struct _IO_FILE *stderr;
#endif
#undef hb_glyph_info_get_glyph_flags
#define HB_MIN_VER(x, y) (HB_VERSION_MAJOR > x || (HB_VERSION_MAJOR == x && HB_VERSION_MINOR >= y))
%}

%apply unsigned int { hb_codepoint_t, hb_tag_t, hb_color_t };
%apply unsigned char { uint8_t };
%apply int { hb_position_t };
%apply SWIGTYPE * { FT_Face };

// prep: sed -e 's/^\(.*\(hb_set_invert\|HB_SCRIPT_CYPRO_MINOAN\|HB_SCRIPT_OLD_UYGHUR\|HB_SCRIPT_TANGSA\|HB_SCRIPT_TOTO\|HB_SCRIPT_VITHKUQI\).*\)$/#if HB_MIN_VER(3,0)`\1`#endif/g' -e 's/^\(.*\(hb_buffer_get_not_found_glyph\|hb_buffer_set_not_found_glyph\).*\)$/#if HB_MIN_VER(3,1)`\1`#endif/g' -e 's/^\(.*\(hb_buffer_create_similar\|hb_font_get_synthetic_slant\|hb_font_get_var_coords_design\|hb_font_set_synthetic_slant\|hb_segment_properties_overlay\).*\)$/#if HB_MIN_VER(3,3)`\1`#endif/g' -e 's/^\(.*\(HB_BUFFER_FLAG_VERIFY\|HB_SCRIPT_MATH\).*\)$/#if HB_MIN_VER(3,4)`\1`#endif/g' -e 's/^\(.*\(hb_font_funcs_set_glyph_shape_func\|hb_font_get_glyph_shape\|HB_GLYPH_FLAG_UNSAFE_TO_CONCAT\|HB_BUFFER_FLAG_PRODUCE_UNSAFE_TO_CONCAT\).*\)$/#if HB_MIN_VER(4,0)`\1`#endif/g' -e 's/^\(.*\(hb_set_add_sorted_array\).*\)$/#if HB_MIN_VER(4,1)`\1`#endif/g' -e 's/^\(.*\(hb_set_next_many\).*\)$/#if HB_MIN_VER(4,2)`\1`#endif/g' -e 's/^\(.*\(hb_font_changed\|hb_font_get_serial\|hb_ft_hb_font_changed\|hb_set_hash\|HB_BUFFER_FLAG_DEFINED\|HB_BUFFER_SERIALIZE_FLAG_DEFINED\).*\)$/#if HB_MIN_VER(4,4)`\1`#endif/g' -e 's/^\(.*\(hb_language_matches\).*\)$/#if HB_MIN_VER(5,0)`\1`#endif/g' -e 's/^\(.*\(HB_GLYPH_FLAG_SAFE_TO_INSERT_TATWEEL\|HB_BUFFER_FLAG_PRODUCE_SAFE_TO_INSERT_TATWEEL\).*\)$/#if HB_MIN_VER(5,1)`\1`#endif/g' -e 's,^\(.*hb_var_num_t.*\)$,/* \1 */,g' | tr '`' '\n'
// exec: sed -e 's/^c-library \(.*\)/cs-vocabulary \1``get-current also \1 definitions``c-library \1/g' -e 's/^end-c-library/end-c-library`previous set-current/g' -e 's/ s n / a n /g' -e 's/s" harfbuzz" add-lib/e? os-type s" linux-android" string-prefix? [IF] s" typeset" [ELSE] s" harfbuzz" [THEN] add-lib/g' | tr '`' '\n'

#define HB_EXTERN extern
#define HB_BEGIN_DECLS
#define HB_END_DECLS

%include "harfbuzz/hb.h"
%include "harfbuzz/hb-blob.h"
%include "harfbuzz/hb-buffer.h"
%include "harfbuzz/hb-common.h"
 // %include "harfbuzz/hb-deprecated.h"
%include "harfbuzz/hb-face.h"
%include "harfbuzz/hb-font.h"
%include "harfbuzz/hb-set.h"
%include "harfbuzz/hb-shape.h"
%include "harfbuzz/hb-shape-plan.h"
%include "harfbuzz/hb-unicode.h"
%include "harfbuzz/hb-version.h"
%include "harfbuzz/hb-ft.h"
