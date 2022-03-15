using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    //Déplacement du joueur

    public KeyCode left;    //Bind une touche sur le déplacment de droite ou de gauche
    public KeyCode right;

    public KeyCode fire;   //Bind une touche pour tirer
    public KeyCode reload;  //Bind une touche pour reload

    public float moveSpeed;   //Mettre une valeur pour la vitesse

    //Créer et gérer le "corp" du player

    private Rigidbody2D theRB;

    //Tirer des munitions

    public Transform firePoint;   //Intégrer la position, l'orientation, la taille, ... du firePoint
    public GameObject ammo;   //Intégrer un objet

    public ammoShooting ammoShooting;

    public int currentAmmo = 10;    //Muniton actuel  
    public int maxAmmo = 10;    //Taille du chargeur

    public TMP_Text textAmmo;   //Transformer la variable int du ndr de ammo en text

    public int rDelay;   //Temps de recharge

    public reloadBarTimer reloadBarTimer;
    public GameObject reloadBarS;

    public int canReload;   //1 = true  0 = false
    public int canShoot;   //1 = true  0 = false

    //Gérer le score

    public int zombKillCount = 0;
    public static float coins = 0;

    public TMP_Text textScore;
    public TMP_Text zombKillCountText;

    //Gérer la vie du joueur

    public int maxHealth = 100;
    public int currentHealth;

    public hpBar hpBar;

    //Gérer l'augementation des compétences

    public int moveSpeedLvl;
    public TMP_Text moveSpeedLvlText;
    public float priceMs;
    public TMP_Text goldNeedMsText;
    public Button moveSpeedLvlButton;

    public int ammoLoaderLvl;
    public TMP_Text ammoLoaderLvlText;
    public float priceAl;
    public TMP_Text goldNeedAlText;
    public Button ammoLoaderLvlButton;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();    //Définir le "corp" du player

        reloadBarS.SetActive(false);

        //Gérer la vie du joueur

        currentHealth = maxHealth;
        hpBar.SetMaxHealth(maxHealth);

        //Gérer l'augementation des compétences

        moveSpeedLvl = 1;
        ammoLoaderLvl = 1;
        priceMs = 3;
        priceAl = 7;

        //Gérer le rechargement

        canReload = 1;
        canShoot = 1;
    }

    void Update()
    {
        //Déplacement du joueur

        if (Input.GetKey(left))    //Si une certaine touche est pressé, alors...
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);    //Déplacement du joueur vers la gauche
        }
        
        else if (Input.GetKey(right))    //Sinon si une certaine touche est pressé, alors...
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);    //Déplacement du joueur vers la droite
        }

        else    //Sinon...
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        //Tirer des munitions et recharger
        
        if (Input.GetKeyDown(fire) && currentAmmo > 0 && canShoot ==1)
        {
            GameObject munitions = (GameObject)Instantiate(ammo, firePoint.position, firePoint.rotation);    //Situer d'où part la munition
            munitions.transform.localScale = transform.localScale;

            currentAmmo--;
        }

        textAmmo.text = currentAmmo.ToString();
        textScore.text = coins.ToString();

        zombKillCountText.text = zombKillCount.ToString();

        if (Input.GetKeyDown(reload) && canReload == 1)
        {
            StartCoroutine(waitShoot());
            StartCoroutine(waitReload());
            StartCoroutine(reloadTime());
            StartCoroutine(barReload());
        }

        //Système d'HP

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        //Gérer l'augementation des compétences

        moveSpeedLvlText.text = moveSpeedLvl.ToString();
        ammoLoaderLvlText.text = ammoLoaderLvl.ToString();
        goldNeedMsText.text = priceMs.ToString();
        goldNeedAlText.text = priceAl.ToString();

        if (moveSpeedLvl == 25)
        {
            moveSpeedLvlText.text = ("Max");
            goldNeedMsText.text = ("Max");
        }

    }

    //Gérer les pièces


    //Gérer les button qui augementent les compétences

    public void IncreaseMs()
    {
        if ( coins >= priceMs )
        {
            moveSpeed = moveSpeed + 5;
            moveSpeedLvl = moveSpeedLvl + 1;

            coins = coins - priceMs;
            coins = Mathf.Round(coins);
            
            priceMs = priceMs * 1.4f;
            priceMs = Mathf.Round(priceMs);

        }

        if ( moveSpeedLvl == 25)
        {
            priceMs = priceMs + 100000;
        }
    }

    public void IncreaseAl()
    {
        if (coins >= priceAl)
        {
            maxAmmo = maxAmmo + 1;
            ammoLoaderLvl = ammoLoaderLvl + 1;

            coins = coins - priceAl;
            coins = Mathf.Round(coins);
            
            priceAl = priceAl * 1.4f;
            priceAl = Mathf.Round(priceAl);
        }
    }

    IEnumerator reloadTime()
    {

        yield return new WaitForSeconds(rDelay);
        currentAmmo = maxAmmo;
    }

    IEnumerator waitReload()
    {
        canReload = 0;
        yield return new WaitForSeconds(1);
        canReload = 1;
    }

    IEnumerator waitShoot()
    {
        canShoot = 0;
        yield return new WaitForSeconds(1);
        canShoot = 1;
    }

    IEnumerator barReload()  //Système pour afficher la bar de reload du tank
    {
        reloadBarS.SetActive(true);

        reloadBarTimer.slider.value = 0;    
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 5;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 10;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 15;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 20;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 25;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 30;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 35;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 40;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 45;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 50;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 55;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 60;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 65;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 70;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 75;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 80;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 85;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 90;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 95;
        yield return new WaitForSeconds(0.05f);
        reloadBarTimer.slider.value = 100;

        reloadBarS.SetActive(false);

    }




}
