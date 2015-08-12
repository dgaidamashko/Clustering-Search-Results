﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StopWords
{
    public class StWdsEng
    {
        public string[] Eng = {
"1","2","3","4","5","6","7","8","9","0",

"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t",
"u","v","w","x","y","z",

"about","above","according","across","actually","ad","adj","ae","af","after","afterwards",
"ag","again","against","ai","al","all","almost","alone","along","already","also","although",
"always","am","among","amongst","an","and","another","any","anyhow","anyone","anything","anywhere","ao","aq",

"ba","bb","bd","be","became","because","become","becomes","becoming","been","before","beforehand","begin","beginning",
"behind","being","below","beside","besides","between","beyond","bf","bg","bh","bi","billion","bj","bm","bn","bo","both",
"br","bs","bt","but","buy","bv","bw","by","bz","ca","can","can't","cannot","caption","cc","cd","cf","cg","ch","ci",
"ck","cl","click","cm","cn","co","co.","com","copy","could","couldn","couldn't","cr","cs","cu","cv","cx","cy","cz",

"de","did","didn","didn't","dj","dk","dm","do","does","doesn","doesn't","don","don't","down","during","dz",

"each","ec","edu","ee","eg","eh","eight","eighty","either","else","elsewhere","end","ending","enough","er",
"es","et","etc","even","ever","every","everyone","everything","everywhere","except",

"few","fi","fifty","find","first","five","fj","fk","fm","fo","for","former","formerly","forty","found","four","fr","free","from","further","fx",
"ga","gb","gd","ge","get","gf","gg","gh","gi","gl","gm","gmt","gn","go","gov","gp","gq","gr","gs","gt","gu","gw","gy",

"had","has","hasn","hasn't","have","haven","haven't","he","he'd","he'll","he's",
"help","hence","her","here","here's","hereafter","hereby","herein","hereupon","hers","herself","him","himself",
"his","hk","hm","hn","home","homepage","how","however","hr","ht","htm","html","http","hu","hundred",
"i'd","i'll","i'm","i've","i.e.","id","ie","if","ii","il","im","in","inc","inc."
,"indeed","information","instead","int","into","io","iq","ir","is","isn","isn't"
,"it","it's","its","itself",
"je","jm","jo","join","jp",
"ke","kg","kh","ki","km","kn","koo","kp","kr","kw","ky","kz",
"la","last","later","latter","lb","lc","least","less","let","let's","li","like",
"likely","lk","ll","lr","ls","lt","ltd","lu","lv","ly",
"ma","made","make","makes","many","maybe","mc","md","me","meantime","meanwhile",
"mg","mh","microsoft","might","mil","million","miss","mk","ml","mm","mn","mo",
"more","moreover","most","mostly","mp","mq","mr","mrs","ms","msie","mt","mu","much","must","mv","mw","mx","my","myself","mz",

"na","namely","nc","ne","neither","net","netscape","never","nevertheless","new",
"next","nf","ng","ni","nine","ninety","nl","no","nobody","none","nonetheless","noone",
"nor","not","nothing","now","nowhere","np","nr","nu","null","nz",

"of","off","often","om","on","once","one","one's","only","onto","or","org","other",
        "others","otherwise","our","ours","ourselves","out","over","overall","own",
"pa","page","pe","per","perhaps","pf","pg","ph","pk","pl","pm","pn","pr","pt","pw","py",
"qa",
"rather","re","recent","recently","reserved","ring","ro","ru","rw",
"sa","same","sb","sc","sd","se","seem","seemed","seeming","seems","seven","seventy"
        ,"several","sg","sh","she","she'd","she'll","she's","should","shouldn","shouldn't",
        "si","since","site","six","sixty","sj","sk","sl","sm","sn","so","some","somehow",
        "someone","something","sometime","sometimes",

"taking","tc","td","ten","text","tf","tg","test","th","than","that","that'll","that's",
        "the","their","them","themselves","then","thence","there","there'll","there's",
        "thereafter","thereby","therefore","therein","thereupon","these","they","they'd",
        "they'll","they're","they've","thirty","t",
"ua","ug","uk","um","under","unless","unlike","unlikely","until","up","upon","us","use","used","using","uy","uz",
"va","vc","ve","very","vg","vi","via","vn","vu",
"was","wasn","wasn't","we","we'd","we'll","we're","we've","web","webpage","website",
        "welcome","well","were","weren","weren't","wf","what","what'll","what's","whatever",
        "when","whence","whenever","where","whereafter","whereas","whereby","wherein","whereupon","wherever","whether","which",
"ye","yes","yet","you","you'd","you'll","you're","you've","your","yours","yourself","yourselves","yt","yu",
"za","zm","zr"

                      };

    public bool Check(string s)
        {
            foreach (string elem in Eng)
            {
                if (s == elem) return true;
            }
            return false;
        }

        
    }

    
}
