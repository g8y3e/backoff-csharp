# GBackoff
[![License][license-image]][license-url]
[![Docs][docs-image]][docs-url]
[![Build status][travis-image]][travis-url]

A simple backoff algorithm in C#

### Usage

#### Simple example

```csharp
 var backoff = new gbase.Backoff();

double firstDuration = backoff.GetDuration(); // will be 1
double secondDuration = backoff.GetDuration(); // will be 2 ... etc.
```

### Example using `Jitter`

Adding randomization to the backoff durations. [See Amazon's writeup of performance gains using jitter](http://www.awsarchitectureblog.com/2015/03/backoff.html).

```csharp
var backoff = new gbase.Backoff(0, 0, 0, true); // last bool variable is enabling Jitter
```
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/hyperium/hyper/master/LICENSE)

[license-image]: https://github.com/g8y3e/backoff-csharp/blob/dev/license.svg?style=flat-square
[license-url]: https://github.com/g8y3e/backoff-csharp/blob/dev/LICENSE
[docs-image]: https://img.shields.io/badge/docs-latest-blue.svg
[docs-url]: https://g8y3e.github.io/backoff-csharp/
[travis-image]: https://travis-ci.org/g8y3e/backoff-csharp.svg?branch=master
[travis-url]: https://travis-ci.org/g8y3e/backoff-csharp
