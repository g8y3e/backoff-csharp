# GBackoff
[![License][license-image]][license-url]
[![Docs][docs-image]][docs-url]
[![Build status][travis-image]][travis-url]

A simple backoff algorithm in C#

### Usage

#### Simple example

```csharp
```

### Example using `Jitter`

Enabling `Jitter` adding randomization to the backoff durations. [See Amazon's writeup of performance gains using jitter](http://www.awsarchitectureblog.com/2015/03/backoff.html).

```csharp
```


[license-image]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square
[license-url]: LICENSE
[docs-image]: https://img.shields.io/badge/docs-latest-blue.svg
[docs-url]: https://g8y3e.github.io/void-engine/
[travis-image]: https://travis-ci.org/g8y3e/backoff-csharp.svg?branch=master
[travis-url]: https://travis-ci.org/g8y3e/backoff-csharp
