using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 写真館システム.Utile
{
    class Data
    {
        public enum 衣装予約モード
        {
            ON,
            OFF
        }

        public enum 性別
        {
            男,
            女
        }

        public enum 撮影目的
        {
            誕生日,
            結婚式,
            年祝い,
            その他記念日,
            入学式,
            卒業式,
            その他行事,
            七五三,
            成人式,
            その他祭事
        }

        public enum DM発送
        {
            可能,
            不可
        }

        public enum ランク
        {
            優良,
            良
        }

        public enum 衣装ランク
        {
            上,
            中,
            下
        }

        public enum 会員種別
        {
            ファミリー会員,
            特別会員

        }

        public enum DM送付区分
        {
            送付可,
            送付不可

        }

        public enum サンプル可否
        {
            送付可,
            送付不可

        }

        public enum 分類
        {
            和装,
            洋装
        }

        public enum 見た目
        {
            モダン調,
            レトロ調
        }

        public enum ブランド
        {
            ブランド品,
            無名
        }

        public enum 色
        {
            黒,
            白,
            赤,
            ピンク,
            グレー
        }

        public enum 柄
        {
            チェック柄,
            無地,
            格子柄
        }

        public enum サイズ
        {
            SS,
            S,
            M,
            L,
            LL,
            XL,
            XLL
            
        }

        public enum 店舗ステータス
        {
            開店中,
            閉店中
        }

        public enum 店舗区分
        {
            自店舗,
            他店舗
        }

        public enum 権限区分
        {
            管理者,
            利用者
        }

        public enum 社員区分
        {
            社員,
            パート

        }

        public enum スタッフステータス
        {
            就業中,
            休職中
        }
        public enum 衣装使用可否
        {
            使用可,
            使用不可
        }

        public enum 衣装ステータス
        {
            レンタル可,
            メインテナンス,
            貸し出し中,
            借りている,
            廃棄予定
        }

        public enum 休日区分
        {
            営業日,
            定休日,
            臨時休業
        }

        public enum 繰り返し
        {
            なし,
            毎週,
            毎月
        }

        public enum 就業区分
        {
            通常勤務 = 0,
            休日出勤 ,
            休日 
        }

        public enum 六曜
        {
            大安,
            赤口,
            先勝,
            友引,
            先負,
            仏滅
        }

        public enum 来店動機
        {
            折込チラシ,
            新聞または広告,
            ご紹介,
            ホームページ,
            ＳＮＳ,
            その他
        }

        public enum 受付ステータス
        {
            予約 = 1, 
            問合せ,
            苦情,
            その他
        }

        //TODO　以下サンプル用のため後で削除
        public enum 店舗名
        {
            名古屋本店,
            静岡支店,
            横浜支店,
        }

        public enum 施設名
        {
            スタジオ１,
            スタジオ２
        }

        public enum タスク区分
        {
            タスクA,
            タスクB,
            タスクC
        }
        public enum スタッフ名
        {
            鈴木一郎,
            佐藤次郎,
            田中三郎
        }
        public enum 商品名
        {
            アルバム,
            キーホルダー,
            額入り写真,
            L版
        }
        public enum 来店区分
        {
            電話予約,
            来店予約,
            予約なし
        }
        public enum 支度区分
        {
            ナチュラル,
            キュート,
            モデル
        }
        public enum 撮影区分
        {
            元気のまま,
            静かに,
            おまかせ
        }
    }
}
