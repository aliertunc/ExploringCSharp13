# C# 13 Yenilikleri

C# 13, kodunuzu daha sade, etkili ve performanslı hale getiren bir dizi güçlü özellikle geliyor. Bu belgede, bu yenilikleri detaylı bir şekilde ele alacağız ve önceki sürümlerle karşılaştırarak neden geliştiriciler için oyun değiştirici olduklarını açıklayacağız.

---

## 1. **params Koleksiyonlarında Geliştirmeler**

### C# 13'teki Yenilik:

Artık `params` anahtar kelimesi, sadece dizilerle sınırlı kalmayıp **List**, **Span** veya **IEnumerable** gibi koleksiyon türleriyle de kullanılabiliyor.

**Örnek (C# 13):**

```csharp
public void PrintNumbers(params List<int> numbers)
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

// Kullanım
PrintNumbers(new List<int> { 1, 2, 3 });
```

### C# 12'deki Durum:

```csharp
public void PrintNumbers(params int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.WriteLine(number);
    }
}

// Kullanım
PrintNumbers(1, 2, 3); // Sadece diziler direkt kullanılabiliyordu.
```

### Neden Yararlı:

Koleksiyonlarla çalışırken esnekliği artırır ve gereksiz dizi dönüştürmelerini önler.

---

## 2. **Yeni `System.Threading.Lock` Türü**

### C# 13'teki Yenilik:

**`System.Threading.Lock`**, paylaşılan kaynaklara erişimi senkronize etmek için yeni bir tür. **`Lock.EnterScope()`** metodu, kritik bölgeyi (critical section) daha temiz ve güvenli bir şekilde yönetmek için **Dispose** düzeninden yararlanır.

**Örnek (C# 13):**

```csharp
Lock myLock = new Lock();
using (myLock.EnterScope())
{
    // Kritik bölge
    Console.WriteLine("Thread-safe kod burada.");
}
```

### C# 12'deki Durum:

```csharp
private static readonly object _lock = new object();

void ThreadSafeMethod()
{
    lock (_lock)
    {
        // Kritik bölge
        Console.WriteLine("Thread-safe kod burada.");
    }
}
```

### Neden Yararlı:

Daha az boilerplate kod ile kilitleri güvenli bir şekilde yöneterek deadlock riskini azaltır ve kod okunabilirliğini artırır.

---

## 3. **Yeni Kaçış Dizisi `\e`**

### C# 13'teki Yenilik:

**`\e`** kaçış dizisi, ESCAPE karakterini temsil etmek için tanıtıldı. Bu, terminal tabanlı uygulamalarda ANSI kodlarını kullanmayı daha kolay hale getirir.

**Örnek (C# 13):**

```csharp
Console.WriteLine("\e[1mBu kalın bir metindir\e[0m");
```

### C# 12'deki Durum:

```csharp
Console.WriteLine("\x1b[1mBu kalın bir metindir\x1b[0m");
```

### Neden Yararlı:

Okunabilirliği artırır ve ANSI kodları ile çalışırken hata yapma olasılığını azaltır.

---

## 4. **Implicit Index Erişimi**

### C# 13'teki Yenilik:

C# 13, koleksiyonların son elemanlarına erişimi kolaylaştırmak için implicit `^` index operatörlerini object initializer'larında destekler.

**Örnek (C# 13):**

```csharp
var initializer = new List<int> { [^1] = 10 }; // Son elemanı 10 olarak ayarlar
```

### C# 12'deki Durum:

```csharp
var initializer = new List<int> { 1, 2, 3, 4, 5 };
initializer[initializer.Count - 1] = 10; // Elle son elemanı ayarlamak gerekirdi.
```

### Neden Yararlı:

Kod temizliğini artırır ve dizi/manipülasyon hatalarını azaltır.

---

## 5. **Async Metotlar ve Iterator'larda `ref` ve Unsafe Desteği**

### C# 13'teki Yenilik:

Artık **async** metotlar ve iterator'lar içerisinde `ref` ve unsafe kod desteği bulunuyor. Önceden bu özellikler yalnızca senkron metotlarla sınırlıydı.

**Örnek (C# 13):**

```csharp
public async Task ProcessDataAsync()
{
    Span<byte> buffer = stackalloc byte[1024]; // Unsafe context
    await Task.Delay(1000);
}
```

### C# 12'deki Durum:

```csharp
void ProcessData()
{
    Span<byte> buffer = stackalloc byte[1024]; // Unsafe context
}

public async Task ProcessDataAsync()
{
    await Task.Run(() => ProcessData());
}
```

### Neden Yararlı:

Asenkron programlamayı sadeleştirilir ve düşük seviyeli bellek manipülasyonları doğrudan desteklenir.

---

## Sonuç

C# 13, geliştiricilerin daha temiz, etkili ve hatasız kod yazmasını sağlamak için önemli adımlar atıyor. Bu yeni özellikler, hem performansı artırır hem de geliştirme deneyimini iyileştirir. 

