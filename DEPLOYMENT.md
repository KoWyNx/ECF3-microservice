# Guide de Déploiement de l'Application E-commerce

Ce document fournit les instructions pour déployer l'application e-commerce en utilisant Docker et Docker Compose.

## Prérequis

- Docker
- Docker Compose

## Services

L'application est composée des services suivants :

1. **Base de données MySQL** - Stocke les données de l'application
2. **Redis** - Utilisé pour le cache
3. **Service d'Authentification** - Gère l'authentification des utilisateurs
4. **Service de Données Communes** - Fournit les données communes pour l'application
5. **Service de Paiement** - Gère le traitement des paiements
6. **Service de Suggestions de Recherche** - Fournit des suggestions de recherche (implémenté en .NET)
7. **Client React** - Application frontend

## Variables d'Environnement

L'application utilise des variables d'environnement pour la configuration. Celles-ci sont définies dans :

- Le fichier `.env` à la racine du projet
- Le fichier `.env` dans le répertoire `client`

> **Note importante pour l'ECF** : Contrairement aux bonnes pratiques habituelles, les fichiers `.env` ont été inclus dans le dépôt Git pour faciliter l'évaluation de l'ECF. Dans un environnement de production réel, ces fichiers devraient être exclus du contrôle de version et gérés séparément.

Le fichier `.env` à la racine contient les variables d'environnement pour les services backend et la base de données. Tous ces fichiers sont déjà configurés et prêts à être utilisés pour le déploiement.

## Étapes de Déploiement

### 1. Construire et Démarrer les Services

```bash
# Construire et démarrer tous les services
docker-compose up -d --build
```

Cette commande construira toutes les images Docker et démarrera les conteneurs en mode détaché.

### 2. Vérifier les Services

```bash
# Vérifier l'état de tous les services
docker ps
```

Tous les services doivent être dans l'état "Up".

### 3. Accéder à l'Application

L'interface React sera disponible à l'adresse :

```
http://localhost:3000
```

### 4. URLs des Services

- Service d'Authentification : http://localhost:7000
- Service de Données Communes : http://localhost:9000
- Service de Paiement : http://localhost:9050
- Service de Suggestions de Recherche : http://localhost:10000



### Visualiser les Logs

```bash
# Voir les logs de tous les services
docker-compose logs

# Voir les logs d'un service spécifique
docker logs <nom-du-service>

# Suivre les logs en temps réel
docker logs -f <nom-du-service>
```

Exemple pour vérifier les logs du service de données communes :

```bash
docker logs common-data-service
```

### Redémarrer un Service

```bash
# Redémarrer un service spécifique
docker-compose restart <nom-du-service>
```

Exemple pour redémarrer le service d'authentification :

```bash
docker-compose restart authentication-service
```

### Reconstruire un Service

Si vous apportez des modifications à un service, vous devez le reconstruire :

```bash
# Reconstruire et redémarrer un service spécifique
docker-compose up -d --build <nom-du-service>
```

Exemple pour reconstruire le service de paiement :

```bash
docker-compose up -d --build payment-service
```

## Problèmes Courants et Solutions

### Problème : Le Service de Données Communes ne démarre pas

Si vous rencontrez des erreurs avec le service de données communes, vérifiez que toutes les variables d'environnement sont correctement définies dans le fichier docker-compose.yml. Les variables suivantes sont nécessaires :

```yaml
PORT: ${COMMON_DATA_SERVICE_PORT}
DB_HOST: mysql
DB_PORT: 3306
DB_SCHEMA: ${MYSQL_DATABASE}
DB_USER: ${MYSQL_USER}
DB_PASS: ${MYSQL_PASSWORD}
REDIS_HOST: redis
REDIS_PORT: 6379
REDIS_PASSWORD: ${REDIS_PASSWORD}
ACTIVE_PROFILE: dev
```

### Problème : Erreurs de Connexion à la Base de Données

Si un service ne peut pas se connecter à la base de données, vérifiez que le conteneur MySQL est en cours d'exécution et que les informations de connexion sont correctes :

```bash
# Vérifier l'état du conteneur MySQL
docker ps | grep mysql

# Vérifier les logs MySQL
docker logs mysql
```
