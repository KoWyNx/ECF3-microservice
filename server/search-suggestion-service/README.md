# Service de Suggestions de Recherche (.NET)

Ce microservice fournit des suggestions de recherche pour l'application e-commerce. Il est construit avec ASP.NET Core et expose des API REST pour les suggestions de recherche.

## Points d'Accès API

- `GET /search-suggestion?q={préfixe}` - Renvoie des suggestions de recherche basées sur le préfixe fourni
- `GET /default-search-suggestion` - Renvoie les suggestions de recherche par défaut

## Développement

### Prérequis

- SDK .NET 9.0
- Docker (pour la conteneurisation)

### Exécution en Local

Pour exécuter le service localement :

```bash
cd SearchSuggestionService
dotnet run
```

Le service sera disponible à l'adresse http://localhost:10000

### Construction de l'Image Docker

```bash
cd SearchSuggestionService
docker build -t search-suggestion-service .
```

### Exécution avec Docker

```bash
docker run -p 10000:10000 -e ASPNETCORE_URLS=http://+:10000 search-suggestion-service
```

## Intégration avec l'Application E-commerce

Ce service fait partie d'une architecture microservices et est utilisé par l'interface React pour fournir des suggestions de recherche aux utilisateurs lorsqu'ils tapent dans la barre de recherche.

## Fonctionnalités

Le service de suggestions de recherche offre les fonctionnalités suivantes :

- Recherche partielle : trouve des correspondances même si l'utilisateur ne tape qu'une partie du mot
- Suggestions par défaut : affiche des suggestions populaires lorsque l'utilisateur n'a pas encore commencé à taper
- Format d'URL compatible : génère des liens qui correspondent exactement au format attendu par le frontend
- Catégorisation : organise les suggestions par catégories de vêtements avec les paramètres appropriés
