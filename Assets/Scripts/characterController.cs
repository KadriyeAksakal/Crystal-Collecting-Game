using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f; // hızı 0.0f'ten 1.0f'e dönüştürüyoruz space kontrolünü kaldırdığımız için
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos; // 3 boyutluda pozisyon verisini tutabilmek için kullanılır.
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _camera; // oyun daha başlamadan SerializeField ile karakterimde kullanacağım özelliği belirlerim.
    // private int sayi;

    void Start() // oyun başladıgında 1 kez çalışır
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // caching spriterenderer
        // oyunun başında özellikleri almaya "caching" denir.
        r2d = GetComponent<Rigidbody2D>(); // karakterime birden fazla özellik vereceğim için getComponent ile tanımlıyorum
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        // sayi = 1;

        // ikisini tanımladığım için oyun başlarken artık kullanabilirim.
    }

    private void FixedUpdate() // fizik hesaplamalarının hepsini burada yapmalıyım. yani fizik hesaplamaları frame basına degil fix update başına yapılacak. Şu anki durumda 50fps yani 50 sn yapılacak
    {
        //Debug.Log("Fixed " + sayi);  
        // kendi fonk yazmak için bunu comment ediyorum.
        // r2d.velocity = new Vector2(speed, 0f); // yani y ekseninde hareket etmeyeceğim, x ekseninde hızım kadar hareket edeceğim.
        // sayi = 2;
    }

    void Update() // her karede çağırılan fonksiyon // per frame olarak çalışır fizik hesaplamaları update'ten önce yapılması gereken hesaplamalar
    {
        // Debug.Log("update " + sayi); // sadece 2 ve 4 yazdırır


        // klavye hareketlerinden karakterimi kontrol etmeye başladığımda burayı kaldırıyoruz artık space ile hız kontrolüme gerek kalmıyor.
        //if (Input.GetKey(KeyCode.Space)) // getKeyDown basılı tutmak için sadece bir kez çalışır, getKey basılı tuttuğu sürece, space tuşuna basılı tuttuğumda 
        //{
        //    speed = 1.0f;
        //    // Debug.Log("Hız 1.0f");
        //}
        //else
        //{
        //    speed = 0.0f;
        //    // Debug.Log("Hız 0.0f");
        //}




        // charPos = new Vector3(charPos.x + (speed * Time.deltaTime), charPos.y); // delta zamanım herbir frame arasındaki zamanı tutuyor dolayısıyla bir frameden diğerine geçerken aradaki fark kadar hızımla beraber çarpıp pozisyonumu değiştireceğim. y'yi değiştirmek istemediğim için charPos.y 'ye atıyorum. Böyle yapınca z'yi otomatik 0 alacak.
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y); // klavye hareketlerime göre karakterimi yönlendirmemi sağlar
        transform.position = charPos; // hesapladığım pozisyon karakterime işlensin


        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        } else
        {
            _animator.SetFloat("speed", 1.0f);
        }


        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }


		// _animator.SetFloat("speed", speed);
        // fizik hesaplamalarını fixedUpdate de yapmam gerektiği için bu satırı yukarıya taşıdım.
        //r2d.velocity = new Vector2(speed, 0f); // yani y ekseninde hareket etmeyeceğim, x ekseninde hızım kadar hareket edeceğim.
        // sayi = 3;
        //Debug.Log("update " + sayi); // sadece 3 yazdırır.
    }


    private void LateUpdate()
    {
        // _camera.transform.position = charPos; // cameramın otomatikman karakterimi takip etmesini sağlarım. kamera ve karakterim tam üst üste geldi bu yüzden z ekseni belirlemeliyim.
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f); // karakterimin bulunduğu yerden 1 metre geri gelmesini istiyorum.
        // sayi = 4;
    }
}
